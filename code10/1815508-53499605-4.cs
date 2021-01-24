    public class Result<T> where T: IEntity
    {
        public int StatusCode { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
