    public class Parent : IDisposable
    {
        private static List<Parent> objList = new List<Parent>();
        private static IReadOnlyList<Parent> readOnlyList = new ReadOnlyCollection<Parent>(objList);
        public static IEnumerable<Parent> Instances { get { return readOnlyList; } }
        private bool _isDisposed = false;
        public bool IsDisposed {  get { return _isDisposed;  } }
        public Parent()
        {
            objList.Add(this);
        }
        public void Dispose()
        {
            OnDispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void OnDispose(bool disposing)
        {
            if(disposing) { objList.Remove(this); }
            _isDisposed = true;
        }
    }
    public class Child : Parent
    {
        private static IEnumerable<Child> _instances = Parent.Instances.OfType<Child>();
        public new static IEnumerable<Child> Instances { get { return _instances; }}
        public Child() : base()
        {
        }
    }
       
