    public static class EntityBaseExtensions
    {
        /// <summary>
        /// Description:    Creates a non-recursive shallow copy of an entity, only including public instance properties decorated with ColumnAttribute.
        ///                 This will return an object without entity references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>A non-recursive shallow copy of a LINQ entity</returns>
        public static T ShallowClone<T>(this T source) where T : EntityBaseClass
        {
            // create an object to copy values into
            T destination = Activator.CreateInstance<T>();
            
            // get source and destination property infos for all public instance
            PropertyInfo[] sourcePropInfos = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] destinationPropInfos = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
            foreach (PropertyInfo sourcePropInfo in sourcePropInfos)
            {
                if (Attribute.GetCustomAttribute(sourcePropInfo, typeof(ColumnAttribute), false) != null)
                {
                    PropertyInfo destPropInfo = destinationPropInfos.Where(pi => pi.Name == sourcePropInfo.Name).First();
    
                    destPropInfo.SetValue(destination, sourcePropInfo.GetValue(source, null), null);
                }
            }
    
            return destination;
        }
    
    }
