    public static string GetDescription<T>(this object enumerationValue)
                where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }
            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0 && attrs.Where(t => t.GetType() == typeof(DescriptionAttribute)).FirstOrDefault() != null)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs.Where(t=>t.GetType() == typeof(DescriptionAttribute)).FirstOrDefault()).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
