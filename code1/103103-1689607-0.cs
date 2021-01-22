    public static class NullSafeExtensions
    {
        /// <summary>
        /// Tests for null/empty strings without re-computing values or assigning temporary variables
        /// </summary>
        /// <typeparam name="TResult">resulting type of the expression</typeparam>
        /// <param name="check">value to check for null</param>
        /// <param name="valueIfNotNullOrEmpty">delegate to compute non-null value</param>
        /// <returns>null if check is null, the delegate's results otherwise</returns>
        public static TResult CheckNullOrEmpty<TResult>(this string check, Func<string, TResult> valueIfNotNullOrEmpty)
            where TResult : class
        {
            return string.IsNullOrEmpty(check) ? null : valueIfNotNullOrEmpty(check);
        }
        /// <summary>
        /// Tests for null/empty collections without re-computing values or assigning temporary variables
        /// </summary>
        /// <typeparam name="TResult">resulting type of the expression</typeparam>
        /// <typeparam name="TCheck">type of collection or array to check</typeparam>
        /// <param name="check">value to check for null</param>
        /// <param name="valueIfNotNullOrEmpty">delegate to compute non-null value</param>
        /// <returns>null if check is null, the delegate's results otherwise</returns>
        public static TResult CheckNullOrEmpty<TCheck, TResult>(this TCheck check, Func<TCheck, TResult> valueIfNotNullOrEmpty)
            where TCheck : ICollection
            where TResult : class
        {
            return (check == null || check.Count == 0) ? null : valueIfNotNullOrEmpty(check);
        }
        /// <summary>
        /// Tests for null objects without re-computing values or assigning temporary variables.  Similar to 
        /// Groovy's "safe-dereference" operator .? which returns null if the object is null, and de-references
        /// if the object is not null.
        /// </summary>
        /// <typeparam name="TResult">resulting type of the expression</typeparam>
        /// <typeparam name="TCheck">type of object to check for null</typeparam>
        /// <param name="check">value to check for null</param>
        /// <param name="valueIfNotNull">delegate to compute if check is not null</param>
        /// <returns>null if check is null, the delegate's results otherwise</returns>
        public static TResult NullSafe<TCheck, TResult>(this TCheck check, Func<TCheck, TResult> valueIfNotNull)
            where TResult : class
            where TCheck : class
        {
            return check == null ? null : valueIfNotNull(check);
        }
    }
