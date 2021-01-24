    public static class Checker
    {
        private static T GetValue<T>(Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }
    
        private static string GetParameterName<T>(Expression<Func<T>> lambda)
        {
            return ((MemberExpression) lambda.Body).Member.Name;
        }
       
        private static void OnViolation(string message)
        {
            // Throw an exception, write to a log or the console etc...
            Console.WriteLine(message);
        }
    
        // Here come the "check"'s and "require"'s as specified in the guideline documents, e.g.
    
        public static void RequireNotEmpty(Expression<Func<string>> lambda)
        {
            if(GetValue(lambda).Length == 0)
            {
                OnViolation($"Non empty value is required for '{GetParameterName(lambda)}'.");
            }
        }
    
        public static void RequireNotNull<T>(Expression<Func<T>> lambda) where T : class
        {
            if(GetValue(lambda) == null)
            {
                OnViolation($"Non null value is required for '{GetParameterName(lambda)}'.");
            }
        }
    
        ...
    }
