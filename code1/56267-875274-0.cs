    public interface ITrustGrid {
        IPagedList Elements { get; set; }
        IList<IColumn> Columns { get; set; }
        IList<string> Headers { get; }
    
        Func<object, string> ElementRenderer { get; }
    }
