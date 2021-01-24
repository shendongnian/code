    public struct ProductId : IXmlSerializable
    {
        readonly string productId;
        public ProductId(string productId)
        {
            this.productId = productId;
        }
        public override string ToString() => productId ?? string.Empty;
        XmlSchema IXmlSerializable.GetSchema() {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader) {
            this = new ProductId(reader.ReadString());
        }
        void IXmlSerializable.WriteXml(XmlWriter writer) {
            writer.WriteString(this.productId);
        }
    }
