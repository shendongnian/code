        static void Main(string[] args)
        {
            SomeMethod(0, "zero");
            // First approach.
            IEnumerable<object> parameters = GetParametersFromConstants(() => SomeMethod(0, "zero"));
            foreach (var p in parameters)
                Console.WriteLine(p);
            // Second approach.
            int thisValue = 0;
            string thatValue = "zero";
            IEnumerable<object> parameters2 = GetParametersFromVariables(() => SomeMethod(thisValue, thatValue));
            foreach (var p in parameters2)
                Console.WriteLine(p);
            Console.ReadLine();
        }
        
        private static void SomeMethod(int thisValue, string thatValue) 
        {
            Console.WriteLine(thisValue + " " + thatValue);
        }      
        private static IEnumerable<object> GetParametersFromVariables(Expression<Action> expr)
        {
            var body = (MethodCallExpression)expr.Body;
            foreach (MemberExpression a in body.Arguments)
            {               
                var test = ((FieldInfo)a.Member).GetValue(((ConstantExpression)a.Expression).Value);
                yield return test;
            }
        }
        private static IEnumerable<object> GetParametersFromConstants(Expression<Action> expr)
        {
            var body = (MethodCallExpression)expr.Body;
            foreach (ConstantExpression a in body.Arguments)
            {
                var test = a.Value;
                yield return test;
            }
        }
    }
