        public static double Evaluate(string expression)
        {
            return (double)new XPathDocument
                (new StringReader("<r/>")).CreateNavigator().Evaluate
                (string.Format("number({0})", new
                                                  Regex(@"([\+\-\*])")
                                                  .Replace(expression, " ${1} ")
                                                  .Replace("/", " div ")
                                                  .Replace("%", " mod ")));
        }
