        private static Func<T, T, T> CreateAdd<T>()
        {
            Func<T, T, T> addMethod = null;
            Expression<Func<T, T, T>> addExpr = null;
            ParameterExpression lhs = Expression.Parameter(typeof(T), "lhs");
            ParameterExpression rhs = Expression.Parameter(typeof(T), "rhs");
            if (typeof(T) == typeof(string))
            {
                //addExpr = (Expression<Func<T, T, T>>)((a, b) => ((T)(object)((string)(object)a + (string)(object)b)));
                addMethod = (a, b) => {
                    string aa = (string)(object)a;
                    string bb = (string)(object)b;
                    string res = aa + bb;
                    return (T)(object)res;
                }; // End Delegate addMethod
            }
            else
            {
                Expression<Func<T, T, T>>.Lambda<Func<T, T, T>>(
                    Expression.Add(lhs, rhs),
                   new ParameterExpression[] { lhs, rhs }
                );
                
                addMethod = addExpr.Compile();
            }
            return addMethod;
        }
        // MvcTools.Aggregate.Functions.Sum<T>(vals);
        public static T Sum<T>(params T[] vals)
        {
            T total = default(T);
            //Enumerable.Aggregate(vals, delegate(T left, T right) { return left + right; }); 
            Func<T, T, T> addMethod = CreateAdd<T>();
            foreach (T val in vals)
            {
                total = addMethod(total, val);
            }
            return total;
        } // End Function Sum
