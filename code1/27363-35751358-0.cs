        public static bool IsIn<T>(this T keyObject, params T[] collection)
        {
            return collection.Contains(keyObject);
        }
        public static bool IsIn<T>(this T keyObject, IEnumerable<T> collection)
        {
            return collection.Contains(keyObject);
        }
        public static bool IsNotIn<T>(this T keyObject, params T[] collection)
        {
            return keyObject.IsIn(collection) == false;
        }
        public static bool IsNotIn<T>(this T keyObject, IEnumerable<T> collection)
        {
            return keyObject.IsIn(collection) == false;
        }
