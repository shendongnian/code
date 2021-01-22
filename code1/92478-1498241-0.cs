    protected TResponse Execute<TResponse>(Expression<Func<TResponse>> command)
    {
        // Check that the expression is in the correct format (ie you are calling a method off of a type Channel
        // Get the name of the method call.  Something like:
            var node = expr.Body as MemberExpression;
            if (object.ReferenceEquals(null, node))
                throw new InvalidOperationException("Expression must be of member access");
            var methodName = node.Member.Name;
        // Use reflection to invoke methodName on otherInstanceOfChannel
        // Cast the results to TResponse and return 
    }
