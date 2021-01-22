    public static class EntityMapper
    {
        public static T Map<T>(params object[] sources) where T : class
        {
            if (!sources.Any())
            {
                return default(T);
            }
 
            var initialSource = sources[0];
 
            var mappingResult = Map<T>(initialSource);
 
            // Now map the remaining source objects
            if (sources.Count() > 1)
            {
                Map(mappingResult, sources.Skip(1).ToArray());
            }
 
            return mappingResult;
        }
 
        private static void Map(object destination, params object[] sources)
        {
            if (!sources.Any())
            {
                return;
            }
 
            var destinationType = destination.GetType();
 
            foreach (var source in sources)
            {
                var sourceType = source.GetType();
                Mapper.Map(source, destination, sourceType, destinationType);
            }
        }
 
        private static T Map<T>(object source) where T : class
        {
            var destinationType = typeof(T);
            var sourceType = source.GetType();
 
            var mappingResult = Mapper.Map(source, sourceType, destinationType);
 
            return mappingResult as T;
        }
    }
 
