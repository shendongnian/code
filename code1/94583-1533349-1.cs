        static string GetFullName(Type t)
        {
            if (!t.IsGenericType)
                return t.Name;
            StringBuilder sb=new StringBuilder();
            sb.Append(t.Name.Substring(0, t.Name.LastIndexOf("`")));
            sb.Append("<");
            Type[] innerTypes = t.GetGenericArguments();
            for(int i=0;i<innerTypes.Length;++i)
            {
                if (i != 0)
                    sb.Append(",");
                sb.Append(GetFullName(innerTypes[i]));
            }
            sb.Append(">");
            return sb.ToString();
        }
