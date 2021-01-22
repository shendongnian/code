        public ProgressBars()
        { }
        private Int32 _ID;
        private string _Name;
        public virtual Int32 ID { get { return _ID; } set { _ID = value; } }
        public virtual string Name { get { return _Name; } set { _Name = value; } }
        public int CompareTo(ProgressBars obj)
        {
            return _Name.CompareTo(obj.Name);
        }        
    } 
