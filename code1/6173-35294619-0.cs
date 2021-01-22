	public static class HttpPostedFileBaseExtension
    {
        /// <summary>
        /// Convert the content to a string.
        /// </summary>
        /// <param name="httpPostedFileBase">The HTTP posted file base.</param>
        /// <returns></returns>
        public static string ExtractContentAsString(this HttpPostedFileBase httpPostedFileBase)
        {
            var startPosition = httpPostedFileBase.InputStream.Position;
            try
            {
                // 1. Check for a BOM
                // 2. or try with UTF-8. The most (86.3%) used encoding. Visit: http://w3techs.com/technologies/overview/character_encoding/all/
                var streamReader = new StreamReader(httpPostedFileBase.InputStream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true), detectEncodingFromByteOrderMarks: true);
                return streamReader.ReadToEnd();
            }
            catch (DecoderFallbackException ex)
            {
                httpPostedFileBase.InputStream.Position = startPosition;
                // 3. The second most (6.7%) used encoding is ISO-8859-1. So use Windows-1252 (0.9%, also know as ANSI), which is a superset of ISO-8859-1.
                var streamReader = new StreamReader(httpPostedFileBase.InputStream, Encoding.GetEncoding(1252));
                return streamReader.ReadToEnd();
            }
            finally
            {
                httpPostedFileBase.InputStream.Position = startPosition;
            }
        }
    }
