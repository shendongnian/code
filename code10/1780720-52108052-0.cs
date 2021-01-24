        static IEnumerable<T> GetConsts<T>(string subClassName)
        {
            var allTypes = Assembly.GetExecutingAssembly().GetTypes();
            var myType = allTypes.FirstOrDefault(t => t.Name.EndsWith(subClassName));
            if (myType == null)
            {
                return Enumerable.Empty<T>();
            }
            var consts = GetConstants(myType);
            var constsOfTypeT = consts
                .Where(c => c.FieldType == typeof(T));
            return constsOfTypeT
                .Select(c => (T)c.GetRawConstantValue());
        }
        /// <summary>
        /// From https://stackoverflow.com/questions/10261824/how-can-i-get-all-constants-of-a-type-by-reflection#10261848
        /// by gdoron
        /// </summary>
        private static List<FieldInfo> GetConstants(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
                 BindingFlags.Static | BindingFlags.FlattenHierarchy);
            return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();
        }
