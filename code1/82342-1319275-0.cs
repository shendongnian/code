    static class PersonExtensions
    {
        public static bool WhereCreatedBefore(this Person p,
            int year, int month, int day)
        {
             return p.CreateDate < new DateTime(year,month,day);
        }
    }
