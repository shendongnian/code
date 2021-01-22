    public static class XmlWriterExt
    {
        /// <summary>
        /// Make sure any previous tag is ended by writing dummy text, then backtracking the position
        /// </summary>
        public static void PrepareStream(this XmlWriter writer, Stream stream)
        {
            writer.WriteElementString("x", string.Empty);
            writer.Flush();
            stream.Position -= 5; //backtrack the dummy element
        }
        /// <summary>
        /// Get an xml writer which works on fragments and without the xml declaration
        /// </summary>
        public static XmlWriter GetWriter(Stream stream)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            XmlWriter xmlWriter = XmlWriter.Create(stream, settings);
            return xmlWriter;
        }
    }
