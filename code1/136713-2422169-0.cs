    public class SelectList
    {
        // Normal SelectList properties/methods go here
        public static Of<T>()
        {
            Type t = typeof(T);
            if (t.IsEnum)
            {
                var values = from Enum e in Enum.GetValues(type)
                             select new { ID = e, Name = e.ToString() };
                return new SelectList(values, "Id", "Name");
            }
            return null;
        }
    }
