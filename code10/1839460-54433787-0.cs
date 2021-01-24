        /// <summary>
        /// Interface to convert string to a type T
        /// </summary>
        public interface IStringToTypeConverter<out T>
        {
            T ConvertToType(string stringToConvertFrom);
    
        }
    
        /// <summary>
        /// Marker Interface to let Serialization/Deserialization work on the ToString Method of the class, Rather than
        /// calling on the Instance properties
        /// </summary>
        public interface ITypeToStringConverter
        {
        }
