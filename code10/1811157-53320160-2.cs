    public interface B
    {
        int J { get; set; }
        IEnumerable<A> KLM { get; }
    }
    public interface B<T> : B where T:A
    {
        int J { get; set; }
        new List<T> KLM { get; set; }
    }
