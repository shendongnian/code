    public class MyValues
    {
        private bool _check;
    
        public bool Check
        {
            get
            {
                return _check;
            }
            set
            {
                if(_check != value)
                {
                    _check = value;
                    // todo: raise event!
                }
            }
        }
    }
