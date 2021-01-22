    foreach (var (BugFixAttribute)attribute in attr)
    {
    	foreach(PropertyInfo prop in attribute.GetType().GetProperties())
    	{
    		Debug.WriteLine(string.Format("{0}: {1}", prop.name,prop.GetValue(attribute,null));
        }
    }
