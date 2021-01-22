    public class SelectList
    {
        public static Of<T>
        {
            IQueryable enumValues = GetAllEnumValues<T>();
            var keyValuePairs = 
                from Enum e in enumValues
                select new { ID = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name");
        }
    }
