    namespace MyNamespace.Collections
    {
        public class SpecialArray<T>
        {
            // Shenanigans
        }
    }
    namespace MyNamespace.BusinessLogic.Filtering
    {
        public static class SpecialArrayExtensions
        {
            public static IEnumerable<T> Filter<T>(this SpecialArray<T> array)
            {
                // validate inputs
                // filter and validate logs in collection
                // in end, return filtered logs, as an enumerable
            }
        }
    }
