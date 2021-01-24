    class Program
    {
        static void main(string[] args)
        {
            ObjectManager objects = new ObjectManager();
            objects.AddObject(objects.CreateObject("object 1"));
            objects.AddObject(objects.CreateObject("object 2"));
            objects.AddObject(objects.CreateObject("object 3"));
        }
    }
    class ObjectManager
    {
        public List<Object> Objects { get; set; }
        public ObjectManager()
        {
            Objects = new List<Object>();
        }
        public Object CreateObject(string name)
        {
            Object o = new Object(name);
            return o;
        }
        public void AddObject(Object o)
        {
            Objects.Add(o);
        }
    }
