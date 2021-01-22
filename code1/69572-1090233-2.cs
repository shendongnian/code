    public class Person
    {
        public string Name 
        { 
            get { return mName; }
            set { mName = value ?? string.empty; }
        }
 
        public Person()
        {
            Name = string.Empty;
        }
        private string mName;
    }
