    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        enum Equation
        {
            A,
            B,
            C
        }
    
        class Result
        {
            public readonly Equation Equation;
            public readonly double Value;
    
            public Result(Equation equation, double value)
            {
                Equation = equation;
                Value = value;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var results = GetGroupedResults();
            }
    
            static ILookup<Equation, Result> GetGroupedResults()
            {
                return GetResults().ToLookup(x => x.Equation);
            }
    
            static List<Result> GetResults()
            {
                return new List<Result>();
            }
        }
    }
