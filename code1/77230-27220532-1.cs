	public void Test(object targetObject, string fieldName)
	{
		FieldInfo field = targetObject.GetType().GetField(fieldName);
		Type elementType;
		bool success = GetArrayElementType(field, out elementType);
	}
