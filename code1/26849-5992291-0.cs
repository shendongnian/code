    private class DummyResolver : XmlResolver
    {
	   public override System.Net.ICredentials Credentials
	   {
		set
		{
         // Do nothing.
        }
	   }
	public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
	   {
		return new System.IO.MemoryStream();
	   }
	}
