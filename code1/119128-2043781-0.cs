    public class XmlContentTypeMapper : WebContentTypeMapper
    {
        public override WebContentFormat
                   GetMessageFormatForContentType(string contentType)
        {
            if (contentType.Contains("text/xml") ||  contentType.Contains("application/xml"))
            {
                return WebContentFormat.Raw;
            }
            else
            {
                return WebContentFormat.Default;
            }
        }
    }
