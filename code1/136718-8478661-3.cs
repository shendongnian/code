    public class SelectList
    {
        public static SelectList Of<T>
        {
            IQueryable enumValues = GetAllEnumValues<T>();
            var values = 
                from Enum e in enumValues
                select new { ID = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name");
        }
    }
