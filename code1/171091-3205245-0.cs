    class SomeObject
    {
        private DataObject[] _data;
        public SomeObject(DataObject[] data)
        {
             _data = data;
        }
        public void Reassign(DataObject o)
        {
            _data[0] = o;
        }
    }
