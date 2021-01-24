    public class PagedResult<T> : PagedResultBase where T : class
    {
        public ICollection<T> Results { get; set; }
        public PagedResult()
        {
            Results = new List<T>();
        }
    }
