     static readonly Regex re = new Regex(@"(\{\S*\})", RegexOptions.Compiled);
            /// <summary>
            /// Pass text and collection of key/value pairs. The text placeholders will be substituted with the collection values.
            /// </summary>
            /// <param name="text">Text that containes placeholders such as {fullname}</param>
            /// <param name="fields">a collection of key values pairs. Pass <code>fullname</code> and the value <code>Sarah</code>. 
            /// DO NOT PASS keys with curly brackets <code>{}</code> in the collection.</param>
            /// <returns>Substituted Text</returns>
            public static string ReplaceMatch(this string text, StringDictionary fields)
            {
                return re.Replace(text, match => fields[match.Groups[1].Value]);
            }
