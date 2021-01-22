    class XmlFakeDtdResolver : XmlUrlResolver
    {
        public static Dictionary<Uri, byte[]> dtdMap = new Dictionary<Uri, byte[]>();
        public static Dictionary<string, Uri> uriMap = new Dictionary<string, Uri>();
        static XmlFakeDtdResolver()
        {
            Uri rss091uri = new Uri("http://fake.uri/rss091");
            uriMap["-//Netscape Communications//DTD RSS 0.91//EN"] = rss091uri;
            uriMap["http://my.netscape.com/publish/formats/rss-0.91.dtd"] = rss091uri;
            dtdMap[rss091uri] = Encoding.ASCII.GetBytes(Resources.rss_0_91dtd);
        }
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            if (dtdMap.ContainsKey(absoluteUri) && ofObjectToReturn == typeof(Stream))
            {
                return new MemoryStream(dtdMap[absoluteUri]);
            }
            return base.GetEntity(absoluteUri, role, ofObjectToReturn);
        }
        public override Uri ResolveUri(Uri baseUri, string relativeUri)
        {
            if (uriMap.ContainsKey(relativeUri))
                return uriMap[relativeUri];
            return base.ResolveUri(baseUri, relativeUri);
        }
    }
