    public class MyList
    {
        private List<SomeClass> PrivateSomeClassList;
        public List<SomeClass> SomeClassList
        {
            get
            {
                return PrivateSomeClassList;
            }
        }
    
        public void Add(SomeClass obj)
        {
            // do whatever you want
            PrivateSomeClassList.Add(obj);
        }
    }
