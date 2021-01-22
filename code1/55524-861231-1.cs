    Type type = TextAttribute.GetType();
    PropertieInfo pi = type.GetProperty("MaxLength");
    if (pi.CanRead())
      //the value
      pi.GetValue();
