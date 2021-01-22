        /// <summary>
        /// Returns replacement value if expression is null
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static long? IsNull(long? expression, long? replacement)
        {
            if (expression.HasValue)
                return expression;
            else
                return replacement;
        }
        /// <summary>
        /// Returns replacement value if expression is null
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string IsNull(string expression, string replacement)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return replacement;
            else
                return expression;
        }
