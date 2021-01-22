    /// <summary>
    /// This service provides helper methods for enums.
    /// </summary>
    public interface IEnumHelperService
    {
        /// <summary>
        /// Maps the enum to dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Dictionary<int, string> MapEnumToDictionary<T>();
    }
    /// <summary>
    /// This service provides helper methods for enums.
    /// </summary>
    /// <seealso cref="Panviva.Status.Probe.Lib.Services.IEnumHelperService" />
    public class EnumHelperService : IEnumHelperService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumHelperService"/> class.
        /// </summary>
        public EnumHelperService()
        {
                
        }
        /// <summary>
        /// Maps the enum to dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">T must be an enumerated type</exception>
        public Dictionary<int, string> MapEnumToDictionary<T>() 
        {
            // Ensure T is an enumerator
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerator type.");
            }
            // Return Enumertator as a Dictionary
            return Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(i => (int)Convert.ChangeType(i, i.GetType()), t => t.ToString());
        }
    }
