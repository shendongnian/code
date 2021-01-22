        private static List<Type> GetAllSubtypesOf(Type anInterface) {
            List<Type> types = new List<Type>();
            ICollection assemblies = buildManager.GetReferencedAssemblies();
            foreach (Assembly assembly in assemblies) {
                Type[] typesInAsm;
                try {
                    typesInAsm = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex) {
                    typesInAsm = ex.Types;
                }
                types.AddRange(typesInAsm.Where(t => anInterface.IsAssignableFrom(t)));
            }
            return types;
        }
