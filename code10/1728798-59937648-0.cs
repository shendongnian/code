    public static void Sanitize<T>(this Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<T> document) where T : class
	{
		for (int i = document.Operations.Count - 1; i >= 0; i--)
		{
			string pathPropertyName = document.Operations[i].path.Split("/", StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
			if (typeof(T).GetProperties().Where(p => p.IsDefined(typeof(DoNotPatchAttribute), true) && string.Equals(p.Name, pathPropertyName, StringComparison.CurrentCultureIgnoreCase)).Any())
			{
				// remove
				document.Operations.RemoveAt(i); 
				//todo: log removal
			}
		}
	}
