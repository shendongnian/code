    private static string XML_SCHEMA_ELEMENT_SET_ELEMENT_TYPE_MEMBER_NAME = "SetElementType";
    
    public static void ChangeElementType(this XmlSchemaElement element, XmlSchemaType type)
    {
            element.GetType().InvokeMember(XML_SCHEMA_ELEMENT_SET_ELEMENT_TYPE_MEMBER_NAME,
                BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
                null, element, new object[] { type });
    }
