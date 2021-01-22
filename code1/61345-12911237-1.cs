    /// <summary>
    /// Extension Methods for Filtering on IQueryable and IEnumerable
    /// </summary>
    internal static class WhereFilterExtensions
    {
        /// <summary>
        /// Filters a sequence of values based on a filter with asterix characters: A*, *A, *A*, A*B
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector">Field to use for filtering. (E.g: item => item.Name)</param>
        /// <param name="filter">Filter: A*, *A, *A*, A*B</param>
        /// <param name="fieldName">Optional description of filter field used in error messages</param>
        /// <returns>Filtered source</returns>
        public static IEnumerable<T> WhereFilter<T>(this IEnumerable<T> source, Func<T, string> selector, string filter, string fieldName)
        {
    
            if (filter == null)
                return source;
    
            if (selector == null)
                return source;
    
            int astrixCount = filter.Count(c => c.Equals('*'));
            if (astrixCount > 2)
                throw new ApplicationException(string.Format("Invalid filter used{0}. '*' can maximum occur 2 times.", fieldName == null ? "" : " for '" + fieldName + "'"));
    
            if (filter.Contains("?"))
                throw new ApplicationException(string.Format("Invalid filter used{0}. '?' is not supported, only '*' is supported.", fieldName == null ? "" : " for '" + fieldName + "'"));
    
    
            // *XX*
            if (astrixCount == 2 && filter.Length > 2 && filter.StartsWith("*") && filter.EndsWith("*"))
            {
                filter = filter.Replace("*", "");
                return source.Where(item => selector.Invoke(item).Contains(filter));
            }
    
            // *XX
            if (astrixCount == 1 && filter.Length > 1 && filter.StartsWith("*"))
            {
                filter = filter.Replace("*", "");
                return source.Where(item => selector.Invoke(item).EndsWith(filter));
            }
    
            // XX*
            if (astrixCount == 1 && filter.Length > 1 && filter.EndsWith("*"))
            {
                filter = filter.Replace("*", "");
                return source.Where(item => selector.Invoke(item).StartsWith(filter));
            }
    
            // X*X
            if (astrixCount == 1 && filter.Length > 2 && !filter.StartsWith("*") && !filter.EndsWith("*"))
            {
                string startsWith = filter.Substring(0, filter.IndexOf('*'));
                string endsWith = filter.Substring(filter.IndexOf('*') + 1);
    
                return source.Where(item => selector.Invoke(item).StartsWith(startsWith) && selector.Invoke(item).EndsWith(endsWith));
            }
    
            // XX
            if (astrixCount == 0 && filter.Length > 0)
            {
                return source.Where(item => selector.Invoke(item).Equals(filter));
            }
    
            // *
            if (astrixCount == 1 && filter.Length == 1)
                return source;
    
            // Invalid Filter
            if (astrixCount > 0)            
                throw new ApplicationException(string.Format("Invalid filter used{0}.", fieldName == null ? "" : " for '" + fieldName + "'"));
    
            // Empty string: all results
            return source;
            
    
        }
        /// <summary>
        /// Filters a sequence of values based on a filter with asterix characters: A*, *A, *A*, A*B
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector">Field to use for filtering. (E.g: item => item.Name)        </param>
        /// <param name="filter">Filter: A*, *A, *A*, A*B</param>
        /// <param name="fieldName">Optional description of filter field used in error messages</param>
        /// <returns>Filtered source</returns>
        public static IQueryable<T> WhereFilter<T>(this IQueryable<T> source, Expression<Func<T, string>> selector, string filter, string fieldName)
        {
            if (filter == null)
                return source;
            if (selector == null)
                return source;
            int astrixCount = filter.Count(c => c.Equals('*'));
            if (astrixCount > 2)
                throw new ApplicationException(string.Format("Invalid filter used{0}. '*' can maximum occur 2 times.", fieldName==null?"":" for '" + fieldName + "'"));
            if (filter.Contains("?"))            
                throw new ApplicationException(string.Format("Invalid filter used{0}. '?' is not supported, only '*' is supported.", fieldName == null ? "" : " for '" + fieldName + "'"));
            // *XX*
            if (astrixCount == 2 && filter.Length > 2 && filter.StartsWith("*") &&         filter.EndsWith("*"))
            {
                filter = filter.Replace("*", "");
                return source.Where(
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "Contains", null,  Expression.Constant(filter)),
                        selector.Parameters[0]
                    )
                );
            }
            // *XX
            if (astrixCount == 1 && filter.Length > 1 && filter.StartsWith("*"))
            {
                filter = filter.Replace("*", "");
                return source.Where(
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "EndsWith", null, Expression.Constant(filter)),
                        selector.Parameters[0]
                    )
                );
            }
            // XX*
            if (astrixCount == 1 && filter.Length > 1 && filter.EndsWith("*"))
            {
                filter = filter.Replace("*", "");
                return source.Where(
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "StartsWith", null,         Expression.Constant(filter)),
                        selector.Parameters[0]
                    )
                );
            }
            // X*X
            if (astrixCount == 1 && filter.Length > 2 && !filter.StartsWith("*") && !filter.EndsWith("*"))
            {
                string startsWith = filter.Substring(0, filter.IndexOf('*'));
                string endsWith = filter.Substring(filter.IndexOf('*') + 1);
        
                return source.Where(
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "StartsWith", null,         Expression.Constant(startsWith)),
                        selector.Parameters[0]
                    )
                ).Where(
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Call(selector.Body, "EndsWith", null,         Expression.Constant(endsWith)),
                        selector.Parameters[0]
                    )
                );
            }
        
            // XX
            if (astrixCount == 0 && filter.Length > 0)
            {
                return source.Where(
                    Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(selector.Body, Expression.Constant(filter)),
                        selector.Parameters[0]
                    )
                );
            }
            // *
            if (astrixCount == 1 && filter.Length == 1)
                return source;
            // Invalid Filter
            if (astrixCount > 0)
                throw new ApplicationException(string.Format("Invalid filter used{0}.", fieldName == null ? "" : " for '" + fieldName + "'"));
            // Empty string: all results
            return source;
        }
    }
