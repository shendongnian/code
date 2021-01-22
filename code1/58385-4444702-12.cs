    public struct EntityName
    {
        public Numbers _num;
        public string _caption;
        public EntityName(Numbers type, string caption)
        {
            _num = type;
            _caption = caption;
        }
        public Numbers GetNumber() 
        {
            return _num;
        }
        public override string ToString()
        {
            return _caption;
        }
    }
