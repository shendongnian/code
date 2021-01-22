    class SomeObject
    {
    }
    
     class MyEnum
     {
        private List<SomeObject> _myList = new List<SomeObject>();
        
        public IEnumerator<SomeObject> GetEnumerator()
        {
            return _myList.GetEnumerator();
        }
     }
