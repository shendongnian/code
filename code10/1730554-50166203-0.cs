    [XmlSchemaProvider("GetSchema")]
    public struct TimeOffset : IXmlSerializable
    {
        public DateTime Time { get; set; }
        public TimeSpan Offset { get; set; }
        public static XmlQualifiedName GetSchema(object xs)
        {
            return new XmlQualifiedName("time", "http://www.w3.org/2001/XMLSchema");
        }
        XmlSchema IXmlSerializable.GetSchema()
        {
            // this method isn't actually used, but is required to be implemented
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var s = reader.NodeType == XmlNodeType.Element
                ? reader.ReadElementContentAsString()
                : reader.ReadContentAsString();
            if (!DateTimeOffset.TryParseExact(s, "HH:mm:ss.FFFFFFFzzz",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var dto))
            {
                throw new FormatException("Invalid time format.");
            }
            this.Time = dto.DateTime;
            this.Offset = dto.Offset;
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            var dto = new DateTimeOffset(this.Time, this.Offset);
            writer.WriteString(dto.ToString("HH:mm:ss.FFFFFFFzzz", CultureInfo.InvariantCulture));
        }
        public string ToShortTimeString()
        {
            return this.Time.ToString("HH:mm", CultureInfo.InvariantCulture);
        }
    }
