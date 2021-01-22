	var myObject = new MyObject();
	foreach( var propertyInfo in myObject.GetType().GetProperties() )
	{
		if(propertyInfo.PropertyType == typeof(string))
		{
			if( propertyInfo.GetValue( myObject, null ) == null )
			{
				propertyInfo.SetValue( myObject, string.Empty, null );
			}
		}
	}
