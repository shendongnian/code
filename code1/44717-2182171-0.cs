    public class AttributeList : List<Attribute>
    {
        /// <summary>
        /// Gets a list of custom attributes
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static AttributeList GetCustomAttributeList(ICustomAttributeProvider propertyInfo)
        {
            var result = new AttributeList();
            result.AddRange(propertyInfo.GetCustomAttributes(false).Cast<Attribute>());
            return result;
        }
        /// <summary>
        /// Finds attribute in collection by its type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T FindAttribute<T>() where T : Attribute
        {
            return (T)Find(x => typeof(T).IsAssignableFrom(x.GetType()));
        }
        public bool IsAttributeSet<T>() where T : Attribute
        {
            return FindAttribute<T>() != null;
        }
    }
