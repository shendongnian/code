        public static string GenericTypeString(this Type t)
        {
            if (!t.IsGenericType)
            {
                return t.GetFullNameWithoutNamespace()
                        .ReplacePlusWithDotInNestedTypeName();
            }
            return t.GetGenericTypeDefinition()
                    .GetFullNameWithoutNamespace()
                    .ReplacePlusWithDotInNestedTypeName()
                    .ReplaceGenericParametersInGenericTypeName(t);
        }
        private static string GetFullNameWithoutNamespace(this Type type)
        {
            if (type.IsGenericParameter)
            {
                return type.Name;
            }
            const int dotLength = 1;
            return type.FullName.Substring(type.Namespace.Length + dotLength);
        }
        private static string ReplacePlusWithDotInNestedTypeName(this string typeName)
        {
            return typeName.Replace('+', '.');
        }
        private static string ReplaceGenericParametersInGenericTypeName(this string typeName, Type t)
        {
            var genericArguments = t.GetGenericArguments();
            const string regexForGenericArguments = @"`[1-9]\d*";
            var rgx = new Regex(regexForGenericArguments);
            typeName = rgx.Replace(typeName, match =>
            {
                var currentGenericArgumentNumbers = int.Parse(match.Value.Substring(1));
                var currentArguments = string.Join(",", genericArguments.Take(currentGenericArgumentNumbers).Select(GenericTypeString));
                genericArguments = genericArguments.Skip(currentGenericArgumentNumbers).ToArray();
                return string.Concat("<", currentArguments, ">");
            });
            return typeName;
        }
