    public static class LinqHelpers
    {
        public static Func<TArg0, TResult> Compile<TContext, TArg0, TResult>
            (this TContext context, 
             Expression<Func<TContext, TArg0, TResult>> query)
            where TContext : DataContext
        {
            Func<TContext, TArg0, TResult> compiled = 
                CompiledQuery.Compile(query);
            return arg => compiled(context, arg);
        }
    }
