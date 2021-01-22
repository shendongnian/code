    internal class Test
    {
        private int _id;
        public virtual int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (ReadOnly)
                {
                    throw new InvalidOperationException("Cannot set properties on a readonly instance.");
                }
            }
        }
    
        private string _name;
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (ReadOnly)
                {
                    throw new InvalidOperationException("Cannot set properties on a readonly instance.");
                }
            }
        }
    
        public bool ReadOnly { get; private set; }
    
        public Test(int id = -1, string name = null)
            : this(id, name, false)
        { }
    
        private Test(int id, string name, bool readOnly)
        {
            ID = id;
            Name = name;
            ReadOnly = readOnly;
        }
    
        public Test AsReadOnly()
        {
            return new Test(ID, Name, true);
        }
    }
