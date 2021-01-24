	private static X509Certificate2 GetCertificate()
	{
		X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
		store.Open(OpenFlags.ReadOnly);
		try
		{
			// Note: X509Certificate2UI requires reference to System.Security
			X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, X509SelectionFlag.SingleSelection);
			if (certs != null && certs.Count > 0)
				return certs[0];
		}
		finally
		{
			store.Close();
		}
		return null;
	}
