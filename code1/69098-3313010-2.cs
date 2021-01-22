    //1 line call to get value
    MyEnums enumValue = (Sections)EnumValue(typeof(Sections), myEnumTextValue, MyEnums.SomeEnumDefault);
    
    //Put this somewhere where you can reuse
    public static object EnumValue(System.Type enumType, string value, object NotDefinedReplacement)
    {
    	if (Enum.IsDefined(enumType, value)) {
    		return Enum.Parse(enumType, value);
    	} else {
    		return Enum.Parse(enumType, NotDefinedReplacement);
    	}
    }
