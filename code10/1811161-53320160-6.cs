    public interface B
    {
        int J { get; set; }
        IEnumerable<A> KLM { get; }
    }
    public interface B<T> : B where T:A
    {
        new List<T> KLM { get; set; }
    }
