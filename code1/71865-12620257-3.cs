	public static T CreateCopy<T>(this T src)
		where T: new()
	{
		if (src == null) return default(T); // just return null
		T tgt = new T(); // create new instance
		// then copy all properties
		foreach (var pS in src.GetType().GetProperties())
		{
			foreach (var pT in tgt.GetType().GetProperties())
			{
				if (pT.Name != pS.Name) continue;
				(pT.GetSetMethod()).Invoke(tgt, new object[] { 
					pS.GetGetMethod().Invoke(src, null) });
			}
		};
		return tgt;
	} // method
