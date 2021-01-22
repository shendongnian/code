    public PagedViewModel<T> Filter<TValue>(Expression<Func<T, TValue>> predicate, FilterType filterType = FilterType.Equals) {
            var name = (predicate.Body as MemberExpression ?? ((UnaryExpression)predicate.Body).Operand as MemberExpression).Member.Name;            
            var value = Expression.Constant(ParamsData[name].To<TValue>(), typeof (T).GetProperty(name).PropertyType);                        
            // If nothing has been set for filter, skip and don't filter data.
            ViewData[name] = m_QueryInternal.Distinct(predicate.Compile()).ToSelectList(name, name, ParamsData[name]);
            if (string.IsNullOrWhiteSpace(ParamsData[name]))
                return this;
            
            var nameExpression = Expression.Parameter(typeof(T), name);
            var propertyExpression = Expression.Property(nameExpression, typeof(T).GetProperty(name));
            // Create expression body based on type of filter
            Expression expression;
            MethodInfo method;
            switch(filterType) {
                case FilterType.Like:
                    method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    expression = Expression.Call(propertyExpression, method, value); 
                    break;
                case FilterType.EndsWith:
                case FilterType.StartsWith:
                    method = typeof(string).GetMethod(filterType.ToString(), new[] { typeof(string) });
                    expression = Expression.Call(propertyExpression, method, value);
                    break;
                case FilterType.GreaterThan:
                    expression = Expression.GreaterThan(propertyExpression, value);                    
                    break;
                case FilterType.Equals:
                    expression = Expression.Equal(propertyExpression, value);
                    break;
                default:
                    throw new ArgumentException("Filter Type could not be determined");
            }            
            
            // Execute the expression against Query.
            var methodCallExpression = Expression.Call(
                typeof (Queryable),
                "Where",
                new[] { Query.ElementType },
                Query.Expression,
                Expression.Lambda<Func<T, bool>>(expression, new[] { nameExpression }));
            
            // Filter the current Query data.
            Query = Query.Provider.CreateQuery<T>(methodCallExpression);            
            return this;
        }
