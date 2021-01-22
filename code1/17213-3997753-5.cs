    public static class TypeExtensions
    {
        public static string GenerateClassDefinition(this Type type)
        {
            var properties = type.GetFields();
            var sb = new StringBuilder();
            var classtext = @"private class $name
            {
             $props}";
            foreach (var p in GetTypeInfo(type, false))
            {
                sb.AppendLine(string.Concat(string.Format("  public {0} {1} ", p.Item2, p.Item1), "{ get; set; }"));
            }
            return classtext.Replace("$name", type.Name).Replace("$props", sb.ToString());
        }
        #region Private Methods
        private static List<Tuple<string, string>> GetTypeInfo(Type type, bool includeProperties)
        {
            var ret = new List<Tuple<string, string>>();
            var fields = type.GetFields();
            var props = type.GetProperties();
            if (includeProperties && fields.Count() > 0)
            {
                foreach (var p in props) ret.Add(new Tuple<string, string>(p.Name, TranslateType(p.PropertyType)));
            }
            foreach (var f in fields) ret.Add(new Tuple<string, string>(f.Name, TranslateType(f.FieldType)));
            return ret;
        }
        private static string TranslateType(Type input)
        {
            string ret;
            if (Nullable.GetUnderlyingType(input) != null)
            {
                ret = string.Format("{0}?", TranslateType(Nullable.GetUnderlyingType(input)));
            }
            else
            {
                switch (input.Name)
                {
                    case "Int32": ret = "int"; break;
                    case "Int64": ret = "long"; break;
                    case "IntPtr": ret = "long"; break;
                    case "Boolean": ret = "bool"; break;
                    case "String":
                    case "Char":
                    case "Decimal":
                        ret = input.Name.ToLower(); break;
                    default: ret = input.Name; break;
                }
            }
            return ret;
        }
        #endregion
    }
