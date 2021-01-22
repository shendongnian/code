    public static class Helper
    {
        /// <summary>
        /// Gets a property if the object is not null.
        /// var teacher = new Teacher();
        /// return teacher.GetProperty(t => t.Name);
        /// return teacher.GetProperty(t => t.Name, "Default name");
        /// </summary>
        public static TSecond GetProperty<TFirst, TSecond>(this TFirst item1,
            Func<TFirst, TSecond> getItem2, TSecond defaultValue = default(TSecond))
        {
            if (item1 == null)
            {
                return defaultValue;
            }
            return getItem2(item1);
        }
    }
