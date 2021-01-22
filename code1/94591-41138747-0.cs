    using System;
    using System.Text;
    
    public static class TypeExtensions
    {
        public static string GetNiceName(this Type type, bool useFullName = false)
        {
            if (!type.IsGenericType) {
                return type.Name;
            }
    
            var typeNameBuilder = new StringBuilder();
            GetNiceGenericName(typeNameBuilder, type, useFullName);
            return typeNameBuilder.ToString();
        }
    
        static void GetNiceGenericName(StringBuilder sb, Type type, bool useFullName)
        {
            if (!type.IsGenericType) {
                sb.Append(useFullName ? type.FullName : type.Name);
                return;
            }
    
            var typeDef = type.GetGenericTypeDefinition();
            var typeName = useFullName ? typeDef.FullName : typeDef.Name;
            sb.Append(typeName);
            sb.Length -= typeName.Length - typeName.LastIndexOf('`');
            sb.Append('<');
            foreach (var typeArgument in type.GenericTypeArguments) {
                GetNiceGenericName(sb, typeArgument, useFullName);
                sb.Append(", ");
            }
            sb.Length -= 2;
            sb.Append('>');
        }
    }
