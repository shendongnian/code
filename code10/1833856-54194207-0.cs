    public static class Example
    {
        enum Day { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        public static void Foo()
        {
            Day day = Day.Tue;
            int dayIndex = day.ToInt();
            // dayIndex = 2
            Day result = (dayIndex + 2).ToEnum<Day>();
            // result = Thu
        }
        public static int ToInt<T>(this T t) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumeration type");
            }
            return Convert.ToInt32(t);
        }
        public static T ToEnum<T>(this int i) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumeration type");
            }
            return (T)Enum.ToObject(typeof(T), i);
        }
    }
