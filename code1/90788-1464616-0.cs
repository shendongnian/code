    public class Content<T>
        {
            public string PageName { get; set; }
    
            public IList<T> SubContent { get; set; } //Note the different def
    
        }
