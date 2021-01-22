        /// <summary>
        /// Gets the type associated with the specified name.
        /// </summary>
        /// <param name="typeName">Full name of the type.</param>
        /// <param name="type">The type.</param>
        /// <param name="customAssemblies">Additional loaded assemblies (optional).</param>
        /// <returns>Returns <c>true</c> if the type was found; otherwise <c>false</c>.</returns>
        public static bool TryGetTypeByName(string typeName, out Type type, params Assembly[] customAssemblies)
        {
            if (typeName.Contains("Version=") 
                && !typeName.Contains("`"))
            {
                // remove full qualified assembly type name
                typeName = typeName.Substring(0, typeName.IndexOf(','));
            }
            type = Type.GetType(typeName);
            if (type == null)
            {
                type = GetTypeFromAssemblies(typeName, customAssemblies);
            }
            // try get generic types
            if (type == null
                && typeName.Contains("`"))
            {
                var match = Regex.Match(typeName, "(?<MainType>.+`(?<ParamCount>[0-9]+))\\[(?<Types>.*)\\]");
                if (match.Success)
                {
                    int genericParameterCount = int.Parse(match.Groups["ParamCount"].Value);
                    string genericDef = match.Groups["Types"].Value;
                    List<string> typeArgs = new List<string>(genericParameterCount);
                    foreach (Match typeArgMatch in Regex.Matches(genericDef, "\\[(?<Type>.*?)\\],?"))
                    {
                        if (typeArgMatch.Success)
                        {
                            typeArgs.Add(typeArgMatch.Groups["Type"].Value.Trim());
                        }
                    }
                    Type[] genericArgumentTypes = new Type[typeArgs.Count];
                    for (int genTypeIndex = 0; genTypeIndex < typeArgs.Count; genTypeIndex++)
                    {
                        Type genericType;
                        if (TryGetTypeByName(typeArgs[genTypeIndex], out genericType, customAssemblies))
                        {
                            genericArgumentTypes[genTypeIndex] = genericType;
                        }
                        else
                        {
                            // cant find generic type
                            return false;
                        }
                    }
                    string genericTypeString = match.Groups["MainType"].Value;
                    Type genericMainType;
                    if (TryGetTypeByName(genericTypeString, out genericMainType))
                    {
                        // make generic type
                        type = genericMainType.MakeGenericType(genericArgumentTypes);
                    }
                }
            }
            return type != null;
        }
        private static Type GetTypeFromAssemblies(string typeName, params Assembly[] customAssemblies)
        {
            Type type = null;
            if (customAssemblies != null
               && customAssemblies.Length > 0)
            {
                foreach (var assembly in customAssemblies)
                {
                    type = assembly.GetType(typeName);
                    if (type != null)
                        return type;
                }
            }
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in loadedAssemblies)
            {
                type = assembly.GetType(typeName);
                if (type != null)
                    return type;
            }          
            return type;
        }
