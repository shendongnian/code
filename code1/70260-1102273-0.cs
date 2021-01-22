    /// <summary>
    /// Retrieve the description of the enum, e.g.
    /// [Description("Bright Pink")]
    /// BrightPink = 2,
    /// </summary>
    /// <param name="value"></param>
    /// <returns>The friendly description of the enum.</returns>
    public static string GetDescription(this Enum value)
    {
      Type type = value.GetType();
    
      MemberInfo[] memInfo = type.GetMember(value.ToString());
    
      if (memInfo != null && memInfo.Length > 0)
      {
        object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
    
        if (attrs != null && attrs.Length > 0)
        {
          return ((DescriptionAttribute)attrs[0]).Description;
        }
      }
    
      return value.ToString();
    }
