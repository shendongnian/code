    public static class XmlHelperExtentions
    {
        /// <summary>
        /// Loads a string through .Load() instead of .LoadXml()
        /// This prevents character encoding problems.
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="xmlString"></param>
        public static void LoadString(this XmlDocument xmlDocument, string xmlString, Encoding encoding = null) {
            if (encoding == null) {
                encoding = Encoding.UTF8;
            }
            // Encode the XML string in a byte array
            byte[] encodedString = encoding.GetBytes(xmlString);
            // Put the byte array into a stream and rewind it to the beginning
            using (var ms = new MemoryStream(encodedString)) {
                ms.Flush();
                ms.Position = 0;
                // Build the XmlDocument from the MemorySteam of UTF-8 encoded bytes
                xmlDocument.Load(ms);
            }
        }
    }
