        /// <summary>
        /// Get a member in an object hierarchy that might contain null references.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source">Base object to get member from.</param>
        /// <param name="getResult">Member path.</param>
        /// <param name="defaultResult">Returned object if object hierarchy is null.</param>
        /// <returns>Default of requested member type.</returns>
        public TResult SafeGet<TSource, TResult>(TSource source, Func<TSource, TResult> getResult, TResult defaultResult)
        {
            // Use EqualityComparer because TSource could by a primitive type.
            if (EqualityComparer<TSource>.Default.Equals(source, default(TSource)))
                return defaultResult;
            try
            {
                return getResult(source);
            }
            catch
            {
                return defaultResult;
            }
        }
        /// <summary>
        /// Get a member in an object hierarchy that might contain null references.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source">Base object to get member from.</param>
        /// <param name="getResult">Member path.</param>
        /// <returns>Default of requested member type.</returns>
        public TResult SafeGet<TSource, TResult>(TSource source, Func<TSource, TResult> getResult)
        {
            // Use EqualityComparer because TSource could by a primitive type.
            if (EqualityComparer<TSource>.Default.Equals(source, default(TSource)))
                return default(TResult);
            try
            {
                return getResult(source);
            }
            catch
            {
                return default(TResult);
            }
        }
