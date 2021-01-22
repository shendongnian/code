    public class AClass
    {
        
        protected List<string> _Items;
        public List<string> Items
        {
            get
            {
                if (_Items == null)
                {
                    _Items = new List<string>();
                }
                return _Items;
            }
        }
    
        
        protected List<string> _Values;
        public List<string> Values
        {
            get
            {
                if (_Values == null)
                {
                    _Values = new List<string>();
                }
                return _Values;
            }
        }
    }
