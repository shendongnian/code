    using System;
    internal static class EnumEnforcer
    {
        /// <summary>
        /// Makes sure that generic input parameter is of an enumerated type.
        /// </summary>
        /// <typeparam name="T">Type that should be checked.</typeparam>
        /// <param name="typeParameterName">Name of the type parameter.</param>
        /// <param name="methodName">Name of the method which accepted the parameter.</param>
        public static void EnforceIsEnum<T>(string typeParameterName, string methodName)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                string message = string.Format(
                    "Generic parameter {0} in {1} method forces an enumerated type. Make sure your type parameter {0} is an enum.",
                    typeParameterName,
                    methodName);
                throw new ArgumentException(message);
            }
        }
        /// <summary>
        /// Makes sure that generic input parameter is of an enumerated type.
        /// </summary>
        /// <typeparam name="T">Type that should be checked.</typeparam>
        /// <param name="typeParameterName">Name of the type parameter.</param>
        /// <param name="methodName">Name of the method which accepted the parameter.</param>
        /// <param name="inputParameterName">Name of the input parameter of this page.</param>
        public static void EnforceIsEnum<T>(string typeParameterName, string methodName, string inputParameterName)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                string message = string.Format(
                    "Generic parameter {0} in {1} method forces an enumerated type. Make sure your input parameter {2} is of correct type.",
                    typeParameterName,
                    methodName,
                    inputParameterName);
                throw new ArgumentException(message);
            }
        }
        /// <summary>
        /// Makes sure that generic input parameter is of an enumerated type.
        /// </summary>
        /// <typeparam name="T">Type that should be checked.</typeparam>
        /// <param name="exceptionMessage">Message to show in case T is not an enum.</param>
        public static void EnforceIsEnum<T>(string exceptionMessage)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
