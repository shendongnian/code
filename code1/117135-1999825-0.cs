    public static void Register<T, TC>() where TC: TypeConverter
    {
     Attribute[] attr = new Attribute[1];
     TypeConverterAttribute vConv = new TypeConverterAttribute(typeof(TC));
          attr[0] = vConv;
     TypeDescriptor.AddAttributes(typeof(T), attr);
    }
