    namespace System
    {
        public static class IEnumerableExtensions
        {
            public static SelectList ToSelectList<T>(this IEnumerable<T> items) where T : class
            {
                return new SelectList(items);
            }
            public static SelectList ToSelectList<T>(this IEnumerable<T> items, object selectedValue) where T : class
            {
                return new SelectList(items, selectedValue);
            }
            public static SelectList ToSelectList<T>(this IEnumerable<T> items, string dataValueField, string dataTextField, object selectedValue) where T : class
            {
                return new SelectList(items, dataValueField, dataTextField, selectedValue);
            }
            public static SelectList ToSelectList<T>(this IEnumerable<T> items, string dataValueField, string dataTextField) where T : class
            {
                return new SelectList(items, dataValueField, dataTextField);
            }
        }
    }
