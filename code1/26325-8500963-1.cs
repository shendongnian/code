    public class EveryDateInTheFuture : IEnumerable<DateTime>
    {
        public EveryDateInTheFuture() { this.StartDate = DateTime.Today; }
    
        public DateTime StartDate { get; set; }
    
        public IEnumerator<DateTime> GetEnumerator()
        {
             while (true)
             {
                 yield return date;
                 date = date.AddDays(1);
             }
        }
    }
