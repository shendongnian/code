    public static class ImagesUtility {
        static IDictionary<string, string> mimeMap = 
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "IVBOR", "png" },
                { "/9J/4", "jpg" },
                //...add others
            };
        
        /// <summary>
        /// Extract image file extension from base64 string.
        /// </summary>
        /// <param name="base64String">base64 string.</param>
        /// <returns>file extension from string.</returns>
        public static string GetFileExtension(string base64String) {
            var data = base64String.Substring(0, 5);        
            var extension = mimeMap[data.ToUpper()];
            return extension;
        }
    }
