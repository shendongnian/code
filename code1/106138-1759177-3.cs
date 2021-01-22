    public static class StringExtensions
    {
        /// <summary>
        /// Parse the <paramref name="target"/> as a <typeparamref name="T"/>. If this cannot be achieved, return the default value of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to parse into.</typeparam>
        /// <param name="target">The string to parse.</param>
        /// <returns>The resultant <typeparamref name="T"/> or the default of <typeparamref name="T"/>.</returns>
        /// <example>
        /// <code>
        /// "1234".Parse&ltint&gt;() == 1234;
        /// "a".Parse&ltint&gt;() == 0;
        /// "a".Parse&ltint?&gt;() == null;
        /// "2010-01-01".Parse&lt;DateTime?&gt;() == new DateTime(2010, 1, 1)
        /// "2010-01-01a".Parse&lt;DateTime?&gt;() == null
        /// "127.0.0.1".Parse&lt;System.Net.IPAddress&gt;().Equals(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }))
        /// "".Parse&lt;System.Net.IPAddress&gt;() == null
        /// </code>
        /// </example>
        public static T Parse<T>(this string target)
        {
            return ParseHelper<T>.Parse(target);
        }
        /// <summary>
        /// Parse the <paramref name="target"/> as a <typeparamref name="T"/>. If this cannot be achieved, return <paramref name="defaultValue"/>
        /// </summary>
        /// <typeparam name="T">The type to parse into.</typeparam>
        /// <param name="target">The string to parse.</param>
        /// <param name="defaultValue">The value to return if <paramref name="target"/> could not be parsed.</param>
        /// <returns>The resultant <typeparamref name="T"/> or <paramref name="defaultValue"/>.</returns>
        /// <example>
        /// <code>
        /// "1234".Parse&ltint&gt;(-1) == 1234;
        /// "a".Parse&ltint&gt;(-1) == -1;
        /// "2010-01-01".Parse&lt;DateTime?&gt;(new DateTime(1900, 1, 1)) == new DateTime(2010, 1, 1)
        /// "2010-01-01a".Parse&lt;DateTime?&gt;(new DateTime(1900, 1, 1)) == new DateTime(1900, 1, 1)
        /// "127.0.0.1".Parse&lt;System.Net.IPAddress&gt;(new System.Net.IPAddress(new byte[] { 0, 0, 0, 0 })).Equals(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }))
        /// "".Parse&lt;System.Net.IPAddress&gt;(new System.Net.IPAddress(new byte[] { 0, 0, 0, 0 })).Equals(new System.Net.IPAddress(new byte[] { 0, 0, 0, 0 }))
        /// </code>
        /// </example>
        public static T Parse<T>(this string target, T defaultValue)
        {
            return ParseHelper<T>.Parse(target, defaultValue);
        }
        private static class ParseHelper<T>
        {
            private static readonly Func<string, T, T, T> _parser;
            static ParseHelper()
            {
                Type type = typeof(T);
                bool isNullable = false;
                if (type.GetGenericArguments().Length > 0 && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    isNullable = true;
                    type = type.GetGenericArguments()[0];
                }
                ParameterExpression target = Expression.Parameter(typeof(string), "target");
                ParameterExpression defaultValue = Expression.Parameter(typeof(T), "defaultValue");
                ParameterExpression result = Expression.Parameter(typeof(T), "result");
                if (isNullable)
                {
                    Type helper = typeof(NullableParseHelper<>);
                    helper = helper.MakeGenericType(typeof(T), type);
                    MethodInfo parseMethod = helper.GetMethod("Parse");
                    _parser = Expression.Lambda<Func<string, T, T, T>>(
                        Expression.Call(parseMethod, target, defaultValue),
                        target, defaultValue, result).Compile();
                }
                else
                {
                    MethodInfo tryParseMethod = (from m in typeof(T).GetMethods()
                                                 where m.Name == "TryParse"
                                                 let ps = m.GetParameters()
                                                 where ps.Count() == 2
                                                    && ps[0].ParameterType == typeof(string)
                                                    && ps[1].ParameterType == typeof(T).MakeByRefType()
                                                 select m).SingleOrDefault();
                    if (tryParseMethod == null)
                    {
                        throw new InvalidOperationException(string.Format("Cannot find method {0}.TryParse(string, out {0})", type.FullName));
                    }
                    _parser = Expression.Lambda<Func<string, T, T, T>>(
                        Expression.Condition(
                            Expression.Call(tryParseMethod, target, result),
                            result,
                            defaultValue),
                        target, defaultValue, result).Compile();
                }
            }
            public static T Parse(string target)
            {
                return _parser.Invoke(target, default(T), default(T));
            }
            public static T Parse(string target, T defaultValue)
            {
                return _parser.Invoke(target, defaultValue, default(T));
            }
            private static class NullableParseHelper<TBase> where TBase : struct
            {
                private static readonly Func<string, TBase?, TBase, TBase?> _parser;
                static NullableParseHelper()
                {
                    MethodInfo tryParseMethod = (from m in typeof(TBase).GetMethods()
                                                 where m.Name == "TryParse"
                                                 let ps = m.GetParameters()
                                                 where ps.Count() == 2
                                                    && ps[0].ParameterType == typeof(string)
                                                    && ps[1].ParameterType == typeof(TBase).MakeByRefType()
                                                 select m).SingleOrDefault();
                    if (tryParseMethod == null)
                    {
                        throw new InvalidOperationException(string.Format("Cannot find method {0}.TryParse(string, out {0})", typeof(TBase).FullName));
                    }
                    ParameterExpression target = Expression.Parameter(typeof(string), "target");
                    ParameterExpression defaultValue = Expression.Parameter(typeof(TBase?), "defaultValue");
                    ParameterExpression result = Expression.Parameter(typeof(TBase), "result");
                    _parser = Expression.Lambda<Func<string, TBase?, TBase, TBase?>>(
                        Expression.Condition(
                            Expression.Call(tryParseMethod, target, result),
                            Expression.ConvertChecked(result, typeof(TBase?)),
                            defaultValue),
                        target, defaultValue, result).Compile();
                }
                public static TBase? Parse(string target, TBase? defaultValue)
                {
                    return _parser.Invoke(target, defaultValue, default(TBase));
                }
            }
        }
    }
