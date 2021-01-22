    public static String GetEnumerationDescription(Enum e)
    {
      Type type = e.GetType();
      FieldInfo fieldInfo = type.GetField(e.ToString());
      DescriptionAttribute[] da = (DescriptionAttribute[])(fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false));
      if (da.Length > 0)
      {
        return da[0].Description;
      }
      return e.ToString();
    }
