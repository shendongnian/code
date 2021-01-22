    using System;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var square = new Square(4);
                Console.WriteLine(square.Calculate());
            }
        }
    
        class MathOp
        {
            protected MathOp(Expression<Func<int>> calc) { _calc = calc.Compile(); }
            public int Calculate() { return _calc(); }
            private Func<int> _calc;
        }
    
        class Square : MathOp
        {
            public Square(int operand)
                : base(() => _operand * _operand)
            {
                _operand = operand;
            }
    
            private int _operand;
        }
    }
