     /// <summary>
        /// UrlDecodes a string without requiring System.Web
        /// </summary>
        /// <param name="text">String to decode.</param>
        /// <returns>decoded string</returns>
        public static string UrlDecode(string text)
        {
            // pre-process for + sign space formatting since System.Uri doesn't handle it
            // plus literals are encoded as %2b normally so this should be safe
            text = text.Replace("+", " ");
            return System.Uri.UnescapeDataString(text);
        }
        /// <summary>
        /// UrlEncodes a string without the requirement for System.Web
        /// </summary>
        /// <param name="String"></param>
        /// <returns></returns>
        public static string UrlEncode(string text)
        {
            // Sytem.Uri provides reliable parsing
            return System.Uri.EscapeDataString(text);
        }
