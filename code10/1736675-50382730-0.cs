    public class MyClass
    {
        private Data _data;
        public Data DataToExpose
        {
            get { return _data; } //expose the internal data as read only
        }
        public struct Data
        {
            public Data(int someData)
            {
                this.SomeData = someData;
            }
            public int SomeData { get; }
        }
    }
