    namespace CalcExp
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                double res = Evaluate("4+5/2-1");
    
                Console.WriteLine(res);
    
            }
    
            public static double Evaluate(string expression)
            {
                var xsltExpression =
                    string.Format("number({0})",
                        new Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
                                                .Replace("/", " div ")
                                                .Replace("%", " mod "));
    
    // ReSharper disable PossibleNullReferenceException
                return (double)new XPathDocument
                    (new StringReader("<r/>"))
                        .CreateNavigator()
                        .Evaluate(xsltExpression);
    // ReSharper restore PossibleNullReferenceException
            }
    
        }
    }
