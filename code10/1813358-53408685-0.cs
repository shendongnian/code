    public class MyObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyObjectLists
    {
        private readonly List<MyObject> _objects;
        public List<MyObject> NullNameObjects
        {
            get
            {
                return _objects.Where(x => x.Name == null).ToList();
            }
        }
        public List<MyObject> NonNullNameObjects
        {
            get
            {
                return _objects.Where(x => x.Name != null).ToList();
            }
        }
        public MyObjectLists(List<MyObject> objects)
        {
            _objects = objects ?? throw new ArgumentNullException(nameof(objects));
        }
    }
