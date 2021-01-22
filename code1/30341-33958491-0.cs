        public static string Description(this Enum value)
        {
            Type type = value.GetType();
            List<string> res = new List<string>();
            var arrValue = value.ToString().Split(',').Select(v=>v.Trim());
            foreach (string strValue in arrValue)
            {
                MemberInfo[] memberInfo = type.GetMember(strValue);
                if (memberInfo != null && memberInfo.Length > 0)
                {
                    object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attrs != null && attrs.Length > 0 && attrs.Where(t => t.GetType() == typeof(DescriptionAttribute)).FirstOrDefault() != null)
                    {
                        res.Add(((DescriptionAttribute)attrs.Where(t => t.GetType() == typeof(DescriptionAttribute)).FirstOrDefault()).Description);
                    }
                    else
                        res.Add(strValue);
                }
                else
                    res.Add(strValue);
            }
            
            return res.Aggregate((s,v)=>s+", "+v);
        }
