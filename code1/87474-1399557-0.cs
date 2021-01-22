    public interface IReadOnly
    {
        string Id
        {
            get;
        }
    }
    
    public interface ICanReadAndWrite
    {
        string Id
        {
            get;
            set;
        }
    }
