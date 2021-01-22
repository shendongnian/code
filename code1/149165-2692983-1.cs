    public class SomeObject
    {
        private List<string> _myList = null;
        
        public List<string> MyList
        {
            get
            {
                if(_myList == null)
                    _myList = new List<string>();
                return _myList;
            }
        }
    }
