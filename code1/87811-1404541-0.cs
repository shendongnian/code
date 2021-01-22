    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    class QueryOrdering<T>
    {
        private Func<IQueryable<T>, IOrderedQueryable<T>> function;
        
        public void AddOrdering<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            if (function == null)
            {
                function = source => source.OrderBy(keySelector);
            }
            else
            {
                // We need to capture the current value...
                var currentFunction = function;
                function = source => currentFunction(source).ThenBy(keySelector);
            }
        }
        
        public IOrderedQueryable<T> Apply(IQueryable<T> source)
        {
            if (function == null)
            {
                throw new InvalidOperationException("No ordering defined");
            }
            return function(source);
        }
    }
