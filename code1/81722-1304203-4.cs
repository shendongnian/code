    public class MyObject
    {
        private static int nextId;
        protected MyObject()
        {
            Id = ++nextId;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public sealed class Builder : Builder<MyObject>
        {
            private MyObject _instance = new MyObject();
            protected override MyObject GetInstance()
            {
                // Validate values here
                return _instance;
            }
            public string Name
            {
                get { return _instance.Name; }
                set { _instance.Name = value; }
            }
        }
    }
