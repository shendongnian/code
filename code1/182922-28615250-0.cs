    public class ObjectDictionary : Dictionary<string, object>
    {
        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="a_source">Source object.</param>
        public ObjectDictionary(object a_source)
            : base(ParseObject(a_source))
        {
            
        }
        /// <summary>
        /// Create a dictionary from the given object (<paramref name="a_source"/>).
        /// </summary>
        /// <param name="a_source">Source object.</param>
        /// <returns>Created dictionary.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="a_source"/> is null.</exception>
        private static IDictionary<String, Object> ParseObject(object a_source)
        {
            #region Argument Validation
            if (a_source == null)
                throw new ArgumentNullException("a_source");
            #endregion
            var type = a_source.GetType();
            var props = type.GetProperties();
            return props.ToDictionary(x => x.Name, x => x.GetValue(a_source, null));
        }
    }
