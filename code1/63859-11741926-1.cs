    public class CustomXmlResolver : XmlResolver
    {
        public CustomXmlResolver() { }
        public override ICredentials Credentials
        {
            set { }
        }
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            MemoryStream entityStream = null;
            switch (absoluteUri.Scheme)
            {
                case "custom-scheme":
                    string absoluteUriOriginalString = absoluteUri.OriginalString;
                    string ctgXsltEntityName = absoluteUriOriginalString.Substring(absoluteUriOriginalString.IndexOf(":") + 1);
                    string entityXslt = "";
                    // TODO: Replace the following with your own code to load data for referenced entities.
                    switch (ctgXsltEntityName)
                    {
                        case "Included.xsl":
                            entityXslt = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">\n  <xsl:template name=\"Included\">\n\n  </xsl:template>\n</xsl:stylesheet>";
                            break;
                    }
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    byte[] entityBytes = utf8Encoding.GetBytes(entityXslt);
                    entityStream = new MemoryStream(entityBytes);
                    break;
            }
            return entityStream;
        }
        public override Uri ResolveUri(Uri baseUri, string relativeUri)
        {
            // You might want to resolve all reference URIs using a custom scheme.
            if (baseUri != null)
                return base.ResolveUri(baseUri, relativeUri);
            else
                return new Uri("custom-scheme:" + relativeUri);
        }
    }
