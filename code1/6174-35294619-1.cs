    public static class StreamExtension
    {
        /// <summary>
        /// Convert the content to a string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static string ReadAsString(this Stream stream)
        {
            var startPosition = stream.Position;
            try
            {
                // 1. Check for a BOM
                // 2. or try with UTF-8. The most (86.3%) used encoding. Visit: http://w3techs.com/technologies/overview/character_encoding/all/
                var streamReader = new StreamReader(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true), detectEncodingFromByteOrderMarks: true);
                return streamReader.ReadToEnd();
            }
            catch (DecoderFallbackException ex)
            {
                stream.Position = startPosition;
                // 3. The second most (6.7%) used encoding is ISO-8859-1. So use Windows-1252 (0.9%, also know as ANSI), which is a superset of ISO-8859-1.
                var streamReader = new StreamReader(stream, Encoding.GetEncoding(1252));
                return streamReader.ReadToEnd();
            }
        }
    }
