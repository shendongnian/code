	[WebMethod]
	public static string GetName()
	{
		return SomeLibraryClass.SomeLibraryFunction(HttpContext.Current.Session);
	}
