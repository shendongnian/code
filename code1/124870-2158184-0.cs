    public class SomeClass()
    {
        private List<string> someList;
        public IList<string> SomeList { 
            get { return someList.AsReadOnly(); }
        }
    }
