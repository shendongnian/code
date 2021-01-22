        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(
                                              typeof(DisplayText),
                                              false);
                if (attrs != null && attrs.Length > 0)
                    return ((DisplayText)attrs[0]).Text;
            }
            return en.ToString();
        }
