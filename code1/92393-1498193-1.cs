    public static class AutoMappingEngine
    {
        public static void CreateMappings(Assembly a)
        {
            Dictionary<Type, IAutoMappingBuddy> mappingDictionary = GetMappingDictionary(a);
            foreach (Type t in a.GetTypes())
            {
                var amba =
                    t.GetCustomAttributes(typeof (AutoMappingBuddyAttribute), true).OfType<AutoMappingBuddyAttribute>().
                        FirstOrDefault();
                if (amba!= null && !mappingDictionary.ContainsKey(amba.MappingBuddy))
                {
                    mappingDictionary.Add(amba.MappingBuddy, amba.CreateBuddy());
                }
            }
            foreach (IAutoMappingBuddy mappingBuddy in mappingDictionary.Values)
            {
                mappingBuddy.CreateMaps();
            }
        }
        private static Dictionary<Type, IAutoMappingBuddy> GetMappingDictionary(Assembly a)
        {
            if (!assemblyMappings.ContainsKey(a))
            {
                assemblyMappings.Add(a, new Dictionary<Type, IAutoMappingBuddy>());
            }
            return assemblyMappings[a];
        }
        private static Dictionary<Assembly, Dictionary<Type, IAutoMappingBuddy>> assemblyMappings = new Dictionary<Assembly, Dictionary<Type, IAutoMappingBuddy>>();
    }
