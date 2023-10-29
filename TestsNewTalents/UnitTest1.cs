using System;
using Xunit;
using NewTalents;

namespace TestsNewTalents
{
    public class UnitTest1
    {

        public Calculadora construirClass()
        {
            string data = "29/10/2023";
            Calculadora calc = new Calculadora(data);

            return calc;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClass();

            int resultadoCalculacodra = calc.Somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculacodra);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClass();

            int resultadoCalculacodra = calc.Multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculacodra);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClass();

            int resultadoCalculacodra = calc.Dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculacodra);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TesteSubtrair(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClass();

            int resultadoCalculacodra = calc.Subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculacodra);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = construirClass();
            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(3,0)
            );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClass();

            calc.Somar(1, 2);
            calc.Somar(2, 8);
            calc.Somar(3, 7);
            calc.Somar(4, 1);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
