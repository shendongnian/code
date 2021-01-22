         public static string ToGenericTypeString(this Type t, params Type[] arg)
        {
            if (t.FullName == null) return t.Name;//Generic argument stub
            bool isGeneric = t.IsGenericType;
            Type genericType = t;
            while (genericType.IsNested && 
               genericType.GetGenericArguments().Count()==t.GetGenericArguments().Count())//Non generic class in a generic class is also considered in Type as being generic
            {
                genericType = genericType.DeclaringType;
            }
            if (!isGeneric) return t.FullName.Replace('+', '.');
            var arguments = arg.Any() ? arg : t.GetGenericArguments();
            string genericTypeName = genericType.GetGenericTypeDefinition().FullName;
            if (genericType.IsNested)
            {
                var argumentsToPass = arguments.Take(genericType.DeclaringType.GetGenericArguments().Count()).ToArray();//Only the innermost will return the actual object and only from the GetGenericArguments directly on the type, not on the on genericDfintion, and only when all parameters including of the innermost are set
                arguments = arguments.Skip(argumentsToPass.Count()).ToArray();
                genericTypeName = genericType.DeclaringType.ToGenericTypeString(argumentsToPass) + "." + genericType.GetGenericTypeDefinition().Name;//Recursive
            }
            if (genericTypeName.IndexOf('`') >= 0)
            {
                genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
                string genericArgs = string.Join(",", arguments.Select(a => a.ToGenericTypeString()).ToArray());
                    //Recursive
                genericTypeName = genericTypeName + "<" + genericArgs + ">";
            }
            if (t != genericType)
            {
                genericTypeName += t.FullName.Replace(genericType.FullName, "").Replace('+','.');
            }
            if (genericTypeName.IndexOf("[") >= 0) genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf("["));//For a non generic class nested in a generic class we will still have the type paramters at the end 
            return genericTypeName;
    }
