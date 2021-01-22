        private static List<Type> GetAllControllerTypes(IBuildManager buildManager) {
            // Go through all assemblies referenced by the application and search for
            // controllers and controller factories.
            List<Type> controllerTypes = new List<Type>();
            ICollection assemblies = buildManager.GetReferencedAssemblies();
            foreach (Assembly assembly in assemblies) {
                Type[] typesInAsm;
                try {
                    typesInAsm = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex) {
                    typesInAsm = ex.Types;
                }
                controllerTypes.AddRange(typesInAsm.Where(IsControllerType));
            }
            return controllerTypes;
        }
