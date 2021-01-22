    class SomeObject
    {
        // you probably want to make this readonly
        private readonly DataObject[] _data;     
        public SomeObject(DataObject[] data)
        {
             _data = data;
        }
        public void ChangeData(DataObject newData)
        {
            _data[0] = o;
        }
        // and you could define your own accessor property...
        private DataObject Data
        {
            get { return _data[0]; }
            set { _data[0] = value; }
        }
    }
