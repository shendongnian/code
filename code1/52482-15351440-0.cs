    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    namespace RPlus.DTO
    {
        /// <summary>
        /// Provide safe string un/concatenating
        /// </summary>
        static class Glob
        {
            // a Regex Split param that basically says:
            // Split on the pipe char unless the preceeding char is a backslash
            private const string _splitterer = @"(?<!\\)\|";
            // no explanation needed (hopefully)
            private const char _delimiter = '|';
            /// <summary>
            /// Produce a properly escaped concatenation
            /// from some number of strings
            /// </summary>
            /// <param name="items">strings to escape/concate</param>
            /// <returns>an escaped concatenation of items</returns>
            public static string To(IEnumerable<string> items)
            {
                var escapedItems = new List<string>();
                foreach (var s in items) escapedItems.Add(Regex.Escape(s));
                return string.Join(_delimiter.ToString(), escapedItems);
            }
            /// <summary>
            /// Unconcatenate/unescape a string into its original strings
            /// </summary>
            /// <param name="globbedValue">
            /// A value returned from Glob.To()
            /// </param>
            /// <returns>
            /// The orignal strings used to construct the globbedValue
            /// </returns>
            public static List<string> From(string globbedValue)
            {
                return From(globbedValue, default(int?));
            }
            /// <summary>
            /// Unconcatenate/unescape a string into its original strings
            /// </summary>
            /// <param name="globbedValue">
            /// A value returned from Glob.To()
            /// </param>
            /// <param name="expectedTokens">
            /// The number of string tokens that 
            /// should be found in the concatenation
            /// </param>
            /// <returns>
            /// The orignal strings used to construct the globbedValue
            /// </returns>
            public static List<string> From(string value, int? expectedTokens)
            {
                var nugs = Regex.Split(value, _splitterer);
                if (expectedTokens.HasValue && nugs.Length != expectedTokens.Value)
                    throw new ArgumentException("Unexpected number of tokens");
                var unescapedItems = new List<string>();
                foreach (var s in nugs) unescapedItems.Add(Regex.Unescape(s));
                return unescapedItems;
            }
        }
    }
