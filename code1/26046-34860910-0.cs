	/// <summary>
	/// Clones a HttpWebRequest for retrying a failed HTTP request.
	/// </summary>
	/// <param name="original"></param>
	/// <returns></returns>
	public static HttpWebRequest Clone(this HttpWebRequest original)
	{
		// Create a new web request object
		HttpWebRequest clone = (HttpWebRequest)WebRequest.Create(original.RequestUri.AbsoluteUri);
		// Get original fields
		PropertyInfo[] properties = original.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
		// There are some properties that we can't set manually for the new object, for various reasons
		List<string> excludedProperties = new List<String>(){ "ContentLength", "Headers" };
		// Traverse properties in HttpWebRequest class
		foreach (PropertyInfo property in properties)
		{
			// Make sure it's not an excluded property
			if (!excludedProperties.Contains(property.Name))
			{
				// Get original field value
				object value = property.GetValue(original);
				// Copy the value to the new cloned object
				if (property.CanWrite)
				{
					property.SetValue(clone, value);
				}
			}
		}
		return clone;
	}
