    public static void RequireNotEmpty(Expression<Func<string>> lambda)
    {
        // Get the passed strings value:
        string value = lambda.Compile().Invoke();
        // Run the check(s) on the value here:
        if (value.Length == 0)
        {
            // Get the name of the passed string:
            string parameterName = ((MemberExpression) lambda.Body).Member.Name;
            Console.WriteLine($"ERROR: Non empty value is required for the expression '{parameterName}'.");
        }
    }
