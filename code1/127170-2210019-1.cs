      public static class EnumExtensions
        {
            public static string ToDescription(this Enum en) 
            {
                Type type = en.GetType();
    
                MemberInfo[] memInfo = type.GetMember(en.ToString());
    
                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),false);
    
                    if (attrs != null && attrs.Length > 0)
    
                        return ((DescriptionAttribute)attrs[0]).Description;
                }
    
                return en.ToString();
            }
            
            public static TEnum NumberToEnum<TEnum>(int number )
            {
                return (TEnum)Enum.ToObject(typeof(TEnum), number);
            }
        }
