        private static readonly string[] acceptedSchemes = { Uri.UriSchemeHttp, Uri.UriSchemeHttps, Uri.UriSchemeMailto, Uri.UriSchemeFile };
        private static readonly char[] forbiddenHrefChars = { '"', '\'', '`', (char)10, (char)13 };
        private static readonly char[] forbiddenBeforeQueryString = { ':', '&', '\\' }; // the colon may look surprising, but if we deal with a colon we expect something which parses as URI
        /// <summary>
        /// Returns true if the specified string is considered XSS safe href attribute value.
        /// </summary>
        public static bool IsSafeHref(string input)
        {
            if (input.Any(c => forbiddenHrefChars.Contains(c)))
                return false;
            // do not accept any entities
            string href = WebUtility.HtmlDecode(input);
            if (href != input)
                return false;
            // check if the scheme is valid, if specified
            bool isUri = Uri.TryCreate(input, UriKind.Absolute, out Uri uri);
            if (uri != null)
                return acceptedSchemes.Contains(uri.Scheme ?? "");
            int qsIdx = href.IndexOf('?');
            string partBeforeQueryString = qsIdx < 0 ? href : href.Substring(0, qsIdx);
            if (forbiddenBeforeQueryString.Any(c => partBeforeQueryString.Contains(c)))
                return false;
            return true;
        }
