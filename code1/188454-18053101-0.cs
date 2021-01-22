    protected virtual ICollection<Something> _somesing { get; set; }
    public static readonly Expression<Func<Model, ICollection<Something>>> Expression = p => p._something;
    
    public IReadOnlyCollection<Something> Something
    {
         return _sumething.AsReadOnly();
    }
