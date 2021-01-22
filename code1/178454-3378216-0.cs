    class Test
    {
        object parent;
        public Test (ref object _parent)
        {
            parent = _parent;
        }
        public object Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }
    object n = null;
    Test t = new Test (ref n);
    n = new Something ();
    t.Parent = n;
