        public static T With<T>(this T item, Action<T> action)
        {
            action(item);
            return item;
        }
