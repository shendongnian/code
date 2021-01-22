    private static T GetEnumValueFromXmlAttrName<T>(string attribVal)
    {
        T val = default(T);
        if (typeof(T).BaseType.FullName.Equals("System.Enum"))
        {
            FieldInfo[] fields = typeof(T).GetFields();
            foreach (FieldInfo field in fields)
            {
                object[] attribs = field.GetCustomAttributes(typeof(XmlEnumAttribute), false);
                foreach (object attr in attribs)
                {
                    if ((attr as XmlEnumAttribute).Name.Equals(attribVal))
                    {
                        val = (T)field.GetValue(null);
                        return val;
                    }
                }
            }
        }
        else
            throw new Exception("The supplied type is not an Enum.");
        return val;
    }
