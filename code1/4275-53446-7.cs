    public abstract class MyObjects<T> where T : IOtherObjects
    {
        List<T> _objects = new List<T>();
        public List<IOtherObjects> Objects
        { get { return _objects; } }
    }
    #warning This won't compile, its for demo's sake.
