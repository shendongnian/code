        public static class AdvancedFormatString
    {
        /// <summary>
        /// An advanced version of string.Format.  If you pass a primitive object (string, int, etc), it acts like the regular string.Format.  If you pass an anonmymous type, you can name the paramters by property name.
        /// </summary>
        /// <param name="formatString"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <example>
        /// "The {Name} family has {Children} children".Format(new { Children = 4, Name = "Smith" })
        /// 
        /// results in 
        /// "This Smith family has 4 children
        /// </example>
        public static string Format(this string formatString, object arg, IFormatProvider format = null)
        {
            if (arg == null)
                return formatString;
            var type = arg.GetType();
            if (Type.GetTypeCode(type) != TypeCode.Object || type.IsPrimitive)
                return string.Format(format, formatString, arg);
            var properties = TypeDescriptor.GetProperties(arg);
            return formatString.Format((property) =>
                {
                    var value = properties[property].GetValue(arg);
                    return Convert.ToString(value, format);
                });
        }
        public static string Format(this string formatString, Func<string, string> formatFragmentHandler)
        {
            if (string.IsNullOrEmpty(formatString))
                return formatString;
            Fragment[] fragments = GetParsedFragments(formatString);
            if (fragments == null || fragments.Length == 0)
                return formatString;
            return string.Join(string.Empty, fragments.Select(fragment =>
                {
                    if (fragment.Type == FragmentType.Literal)
                        return fragment.Value;
                    else
                        return formatFragmentHandler(fragment.Value);
                }).ToArray());
        }
        private static Fragment[] GetParsedFragments(string formatString)
        {
            Fragment[] fragments;
            if ( parsedStrings.TryGetValue(formatString, out fragments) )
            {
                return fragments;
            }
            lock (parsedStringsLock)
            {
                if ( !parsedStrings.TryGetValue(formatString, out fragments) )
                {
                    fragments = Parse(formatString);
                    parsedStrings.Add(formatString, fragments);
                }
            }
            return fragments;
        }
        private static Object parsedStringsLock = new Object();
        private static Dictionary<string,Fragment[]> parsedStrings = new Dictionary<string,Fragment[]>(StringComparer.Ordinal);
        const char OpeningDelimiter = '{';
        const char ClosingDelimiter = '}';
        /// <summary>
        /// Parses the given format string into a list of fragments.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        static Fragment[] Parse(string format)
        {
            int lastCharIndex = format.Length - 1;
            int currFragEndIndex;
            Fragment currFrag = ParseFragment(format, 0, out currFragEndIndex);
            if (currFragEndIndex == lastCharIndex)
            {
                return new Fragment[] { currFrag };
            }
            List<Fragment> fragments = new List<Fragment>();
            while (true)
            {
                fragments.Add(currFrag);
                if (currFragEndIndex == lastCharIndex)
                {
                    break;
                }
                currFrag = ParseFragment(format, currFragEndIndex + 1, out currFragEndIndex);
            }
            return fragments.ToArray();
        }
        /// <summary>
        /// Finds the next delimiter from the starting index.
        /// </summary>
        static Fragment ParseFragment(string format, int startIndex, out int fragmentEndIndex)
        {
            bool foundEscapedDelimiter = false;
            FragmentType type = FragmentType.Literal;
            int numChars = format.Length;
            for (int i = startIndex; i < numChars; i++)
            {
                char currChar = format[i];
                bool isOpenBrace = currChar == OpeningDelimiter;
                bool isCloseBrace = isOpenBrace ? false : currChar == ClosingDelimiter;
                if (!isOpenBrace && !isCloseBrace)
                {
                    continue;
                }
                else if (i < (numChars - 1) && format[i + 1] == currChar)
                {//{{ or }}
                    i++;
                    foundEscapedDelimiter = true;
                }
                else if (isOpenBrace)
                {
                    if (i == startIndex)
                    {
                        type = FragmentType.FormatItem;
                    }
                    else
                    {
                        if (type == FragmentType.FormatItem)
                            throw new FormatException("Two consequtive unescaped { format item openers were found.  Either close the first or escape any literals with another {.");
                        //curr character is the opening of a new format item.  so we close this literal out
                        string literal = format.Substring(startIndex, i - startIndex);
                        if (foundEscapedDelimiter)
                            literal = ReplaceEscapes(literal);
                        fragmentEndIndex = i - 1;
                        return new Fragment(FragmentType.Literal, literal);
                    }
                }
                else
                {//close bracket
                    if (i == startIndex || type == FragmentType.Literal)
                        throw new FormatException("A } closing brace existed without an opening { brace.");
                    string formatItem = format.Substring(startIndex + 1, i - startIndex - 1);
                    if (foundEscapedDelimiter)
                        formatItem = ReplaceEscapes(formatItem);//a format item with a { or } in its name is crazy but it could be done
                    fragmentEndIndex = i;
                    return new Fragment(FragmentType.FormatItem, formatItem);
                }
            }
            if (type == FragmentType.FormatItem)
                throw new FormatException("A format item was opened with { but was never closed.");
            fragmentEndIndex = numChars - 1;
            string literalValue = format.Substring(startIndex);
            if (foundEscapedDelimiter)
                literalValue = ReplaceEscapes(literalValue);
            return new Fragment(FragmentType.Literal, literalValue);
        }
        /// <summary>
        /// Replaces escaped brackets, turning '{{' and '}}' into '{' and '}', respectively.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static string ReplaceEscapes(string value)
        {
            return value.Replace("{{", "{").Replace("}}", "}");
        }
        private enum FragmentType
        {
            Literal,
            FormatItem
        }
        private class Fragment
        {
            public Fragment(FragmentType type, string value)
            {
                Type = type;
                Value = value;
            }
            public FragmentType Type
            {
                get;
                private set;
            }
            /// <summary>
            /// The literal value, or the name of the fragment, depending on fragment type.
            /// </summary>
            public string Value
            {
                get;
                private set;
            }
        }
    }
