    public static class TypeExtensions
    {
        public static string GenerateClassDefinition(this Type type)
        {
            return CreateClass(type, type.Name);
        }
        private static string CreateClass(Type type, string className)
        {
            if (type.GetFields().Count() > 0) return GenerateClassFromFields(type, className);
            else return GeneratereClassFromProperties(type, className);
        }
        private static string GeneratereClassFromProperties(Type type, string className)
        {
            var properties = type.GetProperties();
            var sb = new StringBuilder();
            var classtext = @"private class {0}
    {
    {1}}";
            foreach (var p in properties)
            {
                string name = p.Name;
                string propType = TranslateType(p.PropertyType);
                if (!string.IsNullOrEmpty(propType))
                    sb.AppendLine("  public {0} {1} { get; set; }".Replace("{0}", propType).Replace("{1}", name));
            }
            return classtext.Replace("{0}", className).Replace("{1}", sb.ToString());
        }
        private static string GenerateClassFromFields(Type type, string className)
        {
            var properties = type.GetFields();
            var sb = new StringBuilder();
            var classtext = @"private class {0}
    {
    {1}}";
            foreach (var p in properties)
            {
                string name = p.Name;
                string propType = TranslateType(p.FieldType);
                if (!string.IsNullOrEmpty(propType))
                    sb.AppendLine("  public {0} {1} { get; set; }".Replace("{0}", propType).Replace("{1}", name));
            }
            return classtext.Replace("{0}", className).Replace("{1}", sb.ToString());
        }
        private static string TranslateType(Type input)
        {
            string ret;
            switch (input.Name)
            {
                case "Int32": ret = "int"; break;
                case "Int64": ret = "long"; break;
                case "IntPtr": ret = "long"; break;
                case "Boolean": ret = "bool"; break;
                case "String": ret = "string"; break;
                case "Char": ret = "char"; break;
                default: ret = input.Name; break;
            }
            if (input.Name.Contains("Nullable"))
            {
                ret = "{0}?".FormatString(TranslateType(Nullable.GetUnderlyingType(input)));
            }
            return ret;
        }
    }
