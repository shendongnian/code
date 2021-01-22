    using System;
    using static MathNet.Symbolics.SymbolicExpression;
    using static System.Console;
    using static System.Numerics.Complex;
    using Complex = System.Numerics.Complex;
    
    namespace MathEvaluator
    {
        class Program
        {
            static readonly Complex i = ImaginaryOne;
    
            static void Main(string[] args)
            {
                var z = Variable("z");
                Func<Complex, Complex> f = Parse("z * z").CompileComplex(nameof(z));
                Complex c = 1 / 2 - i / 3;
                WriteLine(f(c));
    
    
                var x = Variable("x");
                Func<double, double> g = Parse("x * x + 5 * x + 6").Compile(nameof(x));
                double a = 1 / 3.0;
                WriteLine(g(a));
            }
        }
    }
