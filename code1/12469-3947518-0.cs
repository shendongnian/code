        public static string ToIndentedString( this XmlDocument doc )
        {
            var stringWriter = new StringWriter(new StringBuilder());
            var xmlTextWriter = new XmlTextWriter(stringWriter) {Formatting = Formatting.Indented};
            doc.Save( xmlTextWriter );
            return stringWriter.ToString();
        }
