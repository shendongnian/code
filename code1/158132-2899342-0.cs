	var r = new System.Xml.XmlTextReader(new StringReader(xml));
	r.XmlResolver = new Resolver();
	var doc = XDocument.Load(r);
	class Resolver : System.Xml.XmlResolver {
		public override Uri ResolveUri (Uri baseUri, string relativeUri)
		{
			return baseUri;
		}
		public override object GetEntity (Uri absoluteUri, string role, Type type)
		{
			return null;
		}		
		public override ICredentials Credentials {
			set {
			}
		}
	}
