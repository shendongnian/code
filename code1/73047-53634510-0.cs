    public class MyXmlReader : XmlTextReader
    {
        public MyXmlReader(TextReader reader) : base(reader) { }
        public override string ReadElementString()
        {
            var text = base.ReadElementString();
            // bool TryParse accepts case-insensitive 'true' and 'false'
            if (bool.TryParse(text, out bool result))
            {
                text = XmlConvert.ToString(result);
            }
            return text;
        }
    }
