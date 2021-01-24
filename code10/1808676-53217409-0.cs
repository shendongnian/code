    public class Parent : IDisposable
    {
        private static List<Parent> objList = new List<Parent>();
        private static IReadOnlyList<Parent> readOnlyList = new ReadOnlyCollection<Parent>(objList);
        public static IEnumerable<Parent> InstanceList { get { return readOnlyList; } }
        private bool _isDisposed = false;
        public bool IsDisposed {  get { return _isDisposed;  } }
        public Parent()
        {
            objList.Add(this);
        }
        ~Parent()
        {
            OnDispose(false);
        }
        public void Dispose()
        {
            OnDispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void OnDispose(bool disposing)
        {
            objList.Remove(this);
            _isDisposed = true;
        }
    }
    public class Child : Parent
    {
        public new static IEnumerable<Child> InstanceList = Parent.InstanceList.Where((p) => typeof(Child).IsAssignableFrom(p.GetType())).Select((p) => (Child)p);
        public Child() : base()
        {
        }
    }
       
