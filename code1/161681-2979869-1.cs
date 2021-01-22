    public static string GetDescription<T>(this T enumerationValue) where T : struct
    {
      var type = enumerationValue.GetType();
      if (!type.IsEnum) throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
      var memberInfo = type.GetMember(enumerationValue.ToString());
      if (memberInfo != null && memberInfo.Length > 0)
      {
        var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attrs != null && attrs.Length > 0)
          return ((DescriptionAttribute) attrs[0]).Description;
      }
      return enumerationValue.ToString();
    }
