            XDocument document;
            using (var stringReader = new StringReader(output))
            {
                var settings = new XmlReaderSettings
                {
                    ProhibitDtd = false,
                    XmlResolver = new LocalXhtmlXmlResolver(bool.Parse(ConfigurationManager.AppSettings["CacheDTDs"]))
                };
                document = XDocument.Load(XmlReader.Create(stringReader, settings));
            }
        private class LocalXhtmlXmlResolver : XmlUrlResolver
        {
            private static readonly Dictionary<string, Uri> KnownUris = new Dictionary<string, Uri>
            {
                { "-//W3C//DTD XHTML 1.0 Strict//EN", new Uri("http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd") },
                { "-//W3C XHTML 1.0 Transitional//EN", new Uri("http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd") },
                { "-//W3C//DTD XHTML 1.0 Transitional//EN", new Uri("http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd") },
                { "-//W3C XHTML 1.0 Frameset//EN", new Uri("http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd") },
                { "-//W3C//DTD XHTML 1.1//EN", new Uri("http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd") }
            };
            private bool enableHttpCaching;
            private ICredentials credentials;
            public LocalXhtmlXmlResolver(bool enableHttpCaching)
            {
                this.enableHttpCaching = enableHttpCaching;
            }
            public override Uri ResolveUri(Uri baseUri, string relativeUri)
            {
                Debug.WriteLineIf(!KnownUris.ContainsKey(relativeUri), "Could not find: " + relativeUri);
                return KnownUris.ContainsKey(relativeUri) ? KnownUris[relativeUri] : base.ResolveUri(baseUri, relativeUri);
            }
            public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
            {
                if (absoluteUri == null)
                {
                    throw new ArgumentNullException("absoluteUri");
                }
                
                //resolve resources from cache (if possible)
                if (absoluteUri.Scheme == "http" && this.enableHttpCaching && (ofObjectToReturn == null || ofObjectToReturn == typeof(Stream)))
                {
                    var request = WebRequest.Create(absoluteUri);
                    
                    request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
                    
                    if (this.credentials != null)
                    {
                        request.Credentials = this.credentials;
                    }
                    
                    var response = request.GetResponse();
                    
                    return response.GetResponseStream();
                }
                
                //otherwise use the default behavior of the XmlUrlResolver class (resolve resources from source)
                return base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
        }
