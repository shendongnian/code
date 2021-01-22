        public static class LinqLikeExtension
    {
        /// <summary> Permits searching a string value with any number of wildcards. This was written 
        /// to handle a variety of EF wildcard queries not supported because the current version is 
        /// less tan EFv6.2, which has a .Like() method.
        /// like in EFv6.</summary>
        /// <typeparam name="T">String or an object with a string member.</typeparam>
        /// <param name="query">Original query</param>
        /// <param name="searchstring">The searchstring</param>
        /// <param name="columnName">The name of the db column, or null if not a column.</param>
        /// <returns>Query filtered by 'LIKE'.</returns>
        /// <example>return iQueryableRows.Like("a", "ReferenceNumber");</example>
        /// <example>return iQueryableRows.Like("a%", "ReferenceNumber");</example>
        /// <example>return iQueryableRows.Like("%b", "ReferenceNumber");</example>
        /// <example>return iQueryableRows.Like("a%b", "ReferenceNumber");</example>
        /// <example>return iQueryableRows.Like("a%b%c", "ReferenceNumber");</example>
        /// <remarks>Linq (C#) is case sensitive, but sql isn't. Use StringComparison ignorecase for Linq.
        /// Keep in mind that Sql however doesn't know StringComparison, so try to determine the provider.</remarks>
        /// <remarks>base author -- Ruard van Elburg from StackOverflow, modifications by dvn</remarks>
        /// <seealso cref="https://stackoverflow.com/questions/1040380/wildcard-search-for-linq"/>
        public static IQueryable<T> Like<T>(this IQueryable<T> query, string searchstring, string columnName = null)
        {
            var eParam = Expression.Parameter(typeof(T), "e");
            var isLinq = (query.Provider.GetType().IsGenericType && query.Provider.GetType().GetGenericTypeDefinition() == typeof(EnumerableQuery<>));
            MethodInfo IndexOf, StartsWith, EndsWith, Equals;
            MethodCallExpression mceCurrent, mcePrevious;
            Expression method = string.IsNullOrEmpty(columnName) ? eParam : (Expression)Expression.Property(eParam, columnName);
            var likeParts = searchstring.Split(new char[] { '%' });
            for (int i = 0; i < likeParts.Length; i++)
            {
                if (likeParts[i] == string.Empty) continue; // "%a"
                if (i == 0)
                {
                    if (likeParts.Length == 1) // "a"
                    {
                        Equals = isLinq
                            ? Equals = typeof(string).GetMethod("Equals", new[] { typeof(string), typeof(StringComparison) })
                            : Equals = typeof(string).GetMethod("Equals", new[] { typeof(string) });
                        mceCurrent = isLinq
                            ? Expression.Call(method, Equals, new Expression[] { Expression.Constant(likeParts[i], typeof(string)), Expression.Constant(StringComparison.OrdinalIgnoreCase) })
                            : Expression.Call(method, Equals, Expression.Constant(likeParts[i], typeof(string)));
                    }
                    else // "a%" or "a%b"
                    {
                        StartsWith = isLinq
                            ? StartsWith = typeof(string).GetMethod("StartsWith", new[] { typeof(string), typeof(StringComparison) })
                            : StartsWith = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                        mceCurrent = isLinq
                            ? Expression.Call(method, StartsWith, new Expression[] { Expression.Constant(likeParts[i], typeof(string)), Expression.Constant(StringComparison.OrdinalIgnoreCase) })
                            : Expression.Call(method, StartsWith, Expression.Constant(likeParts[i], typeof(string)));
                    }
                    query = query.Where(Expression.Lambda<Func<T, bool>>(mceCurrent, eParam));
                }
                else if (i == likeParts.Length - 1)  // "a%b" or "%b"
                {
                    EndsWith = isLinq
                        ? EndsWith = typeof(string).GetMethod("EndsWith", new[] { typeof(string), typeof(StringComparison) })
                        : EndsWith = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
                    mceCurrent = isLinq
                        ? Expression.Call(method, EndsWith, new Expression[] { Expression.Constant(likeParts[i], typeof(string)), Expression.Constant(StringComparison.OrdinalIgnoreCase) })
                        : Expression.Call(method, EndsWith, Expression.Constant(likeParts[i], typeof(string)));
                    query = query.Where(Expression.Lambda<Func<T, bool>>(mceCurrent, eParam));
                }
                else // "a%b%c"
                {
                    IndexOf = isLinq
                        ? IndexOf = typeof(string).GetMethod("IndexOf", new[] { typeof(string), typeof(StringComparison) })
                        : IndexOf = typeof(string).GetMethod("IndexOf", new[] { typeof(string) });
                    mceCurrent = isLinq
                        ? Expression.Call(method, IndexOf, new Expression[] { Expression.Constant(likeParts[i], typeof(string)), Expression.Constant(StringComparison.OrdinalIgnoreCase) })
                        : Expression.Call(method, IndexOf, Expression.Constant(likeParts[i], typeof(string)));
                    mcePrevious = isLinq
                        ? Expression.Call(method, IndexOf, new Expression[] { Expression.Constant(likeParts[i - 1], typeof(string)), Expression.Constant(StringComparison.OrdinalIgnoreCase) })
                        : Expression.Call(method, IndexOf, Expression.Constant(likeParts[i - 1], typeof(string)));
                    query = query.Where(Expression.Lambda<Func<T, bool>>(Expression.LessThan(mcePrevious, mceCurrent), eParam));
                }
            }
            return query;
        }
    }
