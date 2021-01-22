        public object[] Values
        {
            get;
            set;
        }
        public List<object> CategoriesToList()
        {
            List<object> vals = new List<object>();
            vals.AddRange(Values.ToList());
           
            return vals;
        }
