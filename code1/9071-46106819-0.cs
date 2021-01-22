    public static class PathExtensions
    {
        private static HashSet<char> _invalidFilenameChars;
        private static HashSet<char> InvalidFilenameChars
        {
            get { return _invalidFilenameChars ?? (_invalidFilenameChars = new HashSet<char>(Path.GetInvalidFileNameChars())); }
        }
        /// <summary>Replaces characters in <c>text</c> that are not allowed in file names with the 
        /// specified replacement character.</summary>
        /// <param name="text">Text to make into a valid filename. The same string is returned if 
        /// it is valid already.</param>
        /// <param name="replacement">Replacement character, or NULL to remove bad characters.</param>
        /// <param name="fancyReplacements">TRUE to replace quotes and slashes with the non-ASCII characters ” and ⁄.</param>
        /// <returns>A string that can be used as a filename. If the output string would otherwise be empty, "_" is returned.</returns>
        public static string ToValidFilename(this string text, char? replacement = '_', bool fancyReplacements = false)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            HashSet<char> invalids = InvalidFilenameChars;
            bool changed = false;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (invalids.Contains(c))
                {
                    changed = true;
                    char repl = replacement ?? '\0';
                    if (fancyReplacements)
                    {
                        if (c == '"') repl = '”'; // U+201D right double quotation mark
                        else if (c == '\'') repl = '’'; // U+2019 right single quotation mark
                        else if (c == '/') repl = '⁄'; // U+2044 fraction slash
                    }
                    if (repl != '\0')
                        sb.Append(repl);
                }
                else
                    sb.Append(c);
            }
            if (sb.Length == 0)
                return "_";
            return changed ? sb.ToString() : text;
        }
        /// <summary>
        /// Returns TRUE if the specified path is a valid, local filesystem path.
        /// </summary>
        /// <param name="pathString"></param>
        /// <returns></returns>
        public static bool IsValidLocalPath(this string pathString)
        {
            // From solution at https://stackoverflow.com/a/11636052/949129
            Uri pathUri;
            Boolean isValidUri = Uri.TryCreate(pathString, UriKind.Absolute, out pathUri);
            return isValidUri && pathUri != null && pathUri.IsLoopback;
        }
    }
