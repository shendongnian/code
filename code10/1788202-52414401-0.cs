    public class XmlWrapper
    {
        public static XmlReader CreateXmlReaderObject(string sr)
        {
            var settings = new XmlReaderSettings
			{
				ValidationType = ValidationType.None,
				DtdProcessing = DtdProcessing.Ignore,
			};
			return XmlReader.Create(new StringReader(sr));
        }        
    }
