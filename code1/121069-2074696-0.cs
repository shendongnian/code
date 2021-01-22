    object _lock = new object();
    public static Main(string[] args)
    {
        lock(_lock)
        {
             Prop = new T();
        }
 
        T val = null;
        lock(_lock)
        {
             val = Prop;
        }
    }
