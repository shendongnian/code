         /// <summary>
        /// Convert a date to a human readable ISO datetime format. ie. 2012-12-12 23:01:12
        /// this method must be put in a static class. This will appear as an available function
        /// on every datetime objects if your static class namespace is declared.
        /// </summary>
        public static string ToIsoReadable(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH':'mm':'ss");
        }
