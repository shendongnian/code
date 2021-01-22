    class ContainerObject
    {
        public IDictionary<object, object> _dict;
        public ContainerObject(IDictionary<object, object> dict)
        {
            _dict = dict;
        }
        public bool FirstEnabled
        {
            get { return (bool) _dict["FirstEnabled"]; }
            set { _dict["FirstEnabled"] = value; }
        }
    }
