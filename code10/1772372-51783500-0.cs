    public static class Extensions
    {
        public static IQueryable<T> DoSpecificFilter<T>(this DateTime value, IQueryable<T> query)
        {
            DateTime today = DateTime.Now;
            IQueryable<T> ret = query.Where(a => value <= today && today <= value.AddDays(3));
            return ret;
        }
    }
