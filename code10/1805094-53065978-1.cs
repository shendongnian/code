    public static class ExtensionLib {
        public static string GetClassName(this Type objType)
        {
            string result = objType.Name;
            if (objType.IsGenericType)
            {
                var name = objType.Name.Substring(0, objType.Name.IndexOf('`'));
                var genericTypes = objType.GenericTypeArguments.Select(x => x.Name);
                result = $"{name}<{string.Join(",", genericTypes)}>";
            }
            return result;
        }
    }
