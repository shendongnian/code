    public class PagedModelElement<T> where T:class
    {
        public byte Step { get; set; }
        public string Name { get; set; }
        public T Value { get; set; }
    }
    public class PagedModel<T> where T : class
    {
        public IList<PagedModelElement<T>> Objects { get; set; }
    }
