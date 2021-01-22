    public static class EnumHelpers {
      public static string GetDisplayText(this Enum enumValue) {
        var type = enumValue.GetType();
        MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());
     
        if (memberInfo == null || memberInfo.Length == 0)
          return enumValue.ToString();
           
        object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayTextAttribute), false);
        if (attributes == null || attributes.Length == 0)
          return enumValue.ToString();
        
        return ((DisplayTextAttribute)attributes[0]).Text;
      }
    }
