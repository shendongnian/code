    public class DateTimeEnumerator : System.Collections.IEnumerable
    {
        private DateTime begin;
        private DateTime end;
        public DateTimeEnumerator ( DateTime begin , DateTime end ) 
        {
            // probably create a defensive copy here... 
            this.begin = begin;
            this.end = end;
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            for(DateTime date = begin; date < end; date = date.AddDays(1))
            {
                yield return date;
            }
        }
    }
