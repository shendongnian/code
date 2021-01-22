    /// <summary>
    /// Provides various pieces of helper functionality for value types.
    /// </summary>
    /// <typeparam name="T">The value type T to operate on.</typeparam>
    public static class TypeHelper<T> where T : struct {
        private delegate bool TryParseFunc(string str, out T result);
        private static TryParseFunc tryParseFuncCached;
        private static TryParseFunc tryParseCached {
            get {
                return tryParseFuncCached ?? (tryParseFuncCached = Delegate.CreateDelegate(typeof(TryParseFunc), typeof(T), "TryParse") as TryParseFunc);
            }
        }
        /// <summary>
        /// Tries to convert the specified string representation of a logical value to
        /// its type T equivalent. A return value indicates whether the conversion
        /// succeeded or failed.
        /// </summary>
        /// <param name="value">A string containing the value to try and convert.</param>
        /// <param name="result">If the conversion was successful, the converted value of type T.</param>
        /// <returns>If value was converted successfully, true; otherwise false.</returns>
        public static bool TryParse(string value, out T result) {
            return tryParseCached(value, out result);
        }
        /// <summary>
        /// Tries to convert the specified string representation of a logical value to
        /// its type T equivalent. A return value indicates whether the conversion
        /// succeeded or failed.
        /// </summary>
        /// <param name="value">A string containing the value to try and convert.</param>
        /// <returns>If value was converted successfully, true; otherwise false.</returns>
        public static bool TryParse(string value) {
            T throwaway;
            return TryParse(value, out throwaway);
        }
    }
