        private static Func<T, T, T> CreateAdd<T>()
        {
            Func<T, T, T> addMethod = null;
            Expression<Func<T, T, T>> addExpr = null;
            if (typeof(T) == typeof(string))
            {
                //addExpr = (Expression<Func<T, T, T>>)((a, b) => ((T)(object)((string)(object)a + (string)(object)b)));
                //addMethod = addExpr.Compile();
                
                addMethod = (a, b) => {
                    string aa = (string)(object)a;
                    string bb = (string)(object)b;
                    double da;
                    double db;
                    double.TryParse(aa, out da);
                    double.TryParse(bb, out db);
                    double c = da + db;
                    string res = c.ToString();
                    return (T)(object)res;
                }; // End Delegate addMethod
            }
            else
            {
                ParameterExpression lhs = Expression.Parameter(typeof(T), "lhs");
                ParameterExpression rhs = Expression.Parameter(typeof(T), "rhs");
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
