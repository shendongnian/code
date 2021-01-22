        /// <summary>
        /// Repeats a System.String instance by the number of times specified;
        /// Each copy of thisString is separated by a separator
        /// </summary>
        /// <param name="thisString">
        /// The current string to be repeated
        /// </param>
        /// <param name="separator">
        /// Separator in between copies of thisString
        /// </param>
        /// <param name="repeatTimes">
        /// The number of times thisString is repeated</param>
        /// <returns>
        /// A repeated copy of thisString by repeatTimes times 
        /// and separated by the separator
        /// </returns>
        public static string Repeat(this string thisString, string separator, int repeatTimes) {
            return string.Join(separator, ParallelEnumerable.Repeat(thisString, repeatTimes));
        }
