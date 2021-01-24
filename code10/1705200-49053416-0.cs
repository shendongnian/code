    static class Exts
    {
        public static string ToCSharpString(this Type type, StringBuilder sb = null)
        {
            sb = sb ?? new StringBuilder();
            if (type.IsGenericType)
            {
                sb.Append(type.Name.Split('`')[0]);
                sb.Append('<');
                bool first = true;
                foreach (var tp in type.GenericTypeArguments)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    sb.Append(tp.ToCSharpString());
                }
                sb.Append('>');
            }
            else if (type.IsArray)
            {
                sb.Append(type.GetElementType().ToCSharpString());
                sb.Append("[]");
            }
            else
            {
                sb.Append(type.Name);
            }
            return sb.ToString();
        }
    }
