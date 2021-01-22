    MethodInfo convertMethod;
	if( Type.GetTypeCode(type) != TypeCode.String )
		convertMethod = typeof(XmlConvert).GetMethod ( "To" + type.Name );
	else
		convertMethod = E.InnerText.GetType().GetMethod("Clone");
	if( convertMethod == null )
	{
		//Error
	}
	else
	{
		if( Type.GetTypeCode (type)!= TypeCode.String )
			newVar = (T)convertMethod.Invoke( null, new object[] { E.InnerText } );
		else
			newVar = (T)convertMethod.Invoke ( E.InnerText, new object[]{} );
	}
