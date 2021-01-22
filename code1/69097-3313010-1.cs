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
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik, @toddanglin
    //Facebook: facebook.com/telerik
    //=======================================================
