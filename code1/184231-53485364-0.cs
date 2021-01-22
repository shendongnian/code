        public static Type ReconstructType(string assemblyQualifiedName, bool throwOnError = true, params Assembly[] referencedAssemblies)
        {
            foreach (Assembly asm in referencedAssemblies)
            {
                var fullNameWithoutAssemblyName = assemblyQualifiedName.Replace($", {asm.FullName}", "");
                var type = asm.GetType(fullNameWithoutAssemblyName, throwOnError: false);
                if (type != null) return type;
            }
            if (assemblyQualifiedName.Contains("[["))
            {
                Type type = ConstructGenericType(assemblyQualifiedName, throwOnError);
                if (type != null)
                    return type;
            }
            else
            {
                Type type = Type.GetType(assemblyQualifiedName, false);
                if (type != null)
                    return type;
            }
            if (throwOnError)
                throw new Exception($"The type \"{assemblyQualifiedName}\" cannot be found in referenced assemblies.");
            else
                return null;
        }
        private static Type ConstructGenericType(string assemblyQualifiedName, bool throwOnError = true)
        {
            Regex regex = new Regex(@"^(?<name>\w+(\.\w+)*)`(?<count>\d)\[(?<subtypes>\[.*\])\](, (?<assembly>\w+(\.\w+)*)[\w\s,=\.]+)$?", RegexOptions.Singleline | RegexOptions.ExplicitCapture);
            Match match = regex.Match(assemblyQualifiedName);
            if (!match.Success)
                if (!throwOnError) return null;
                else throw new Exception($"Unable to parse the type's assembly qualified name: {assemblyQualifiedName}");
            string typeName = match.Groups["name"].Value;
            int n = int.Parse(match.Groups["count"].Value);
            string asmName = match.Groups["assembly"].Value;
            string subtypes = match.Groups["subtypes"].Value;
            typeName = typeName + $"`{n}";
            Type genericType = ReconstructType(typeName, throwOnError);
            if (genericType == null) return null;
            List<string> typeNames = new List<string>();
            int ofs = 0;
            while (ofs < subtypes.Length && subtypes[ofs] == '[')
            {
                int end = ofs, level = 0;
                do
                {
                    switch (subtypes[end++])
                    {
                        case '[': level++; break;
                        case ']': level--; break;
                    }
                } while (level > 0 && end < subtypes.Length);
                if (level == 0)
                {
                    typeNames.Add(subtypes.Substring(ofs + 1, end - ofs - 2));
                    if (end < subtypes.Length && subtypes[end] == ',')
                        end++;
                }
                ofs = end;
                n--;  // just for checking the count
            }
            if (n != 0)
                // This shouldn't ever happen!
                throw new Exception("Generic type argument count mismatch! Type name: " + assemblyQualifiedName);  
            Type[] types = new Type[typeNames.Count];
            for (int i = 0; i < types.Length; i++)
            {
                try
                {
                    types[i] = ReconstructType(typeNames[i], throwOnError);
                    if (types[i] == null)  // if throwOnError, should not reach this point if couldn't create the type
                        return null;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable to reconstruct generic type. Failed on creating the type argument {(i + 1)}: {typeNames[i]}. Error message: {ex.Message}");
                }
            }
            Type resultType = genericType.MakeGenericType(types);
            return resultType;
        }
