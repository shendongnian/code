    public class C
    {
        public C() { }
        
        string someData = string.Empty;
        public string SomeData
        {
            get
            {
                if (string.IsNullOrEmpty(someData))
                    this.LoadSomeData();
                return someData;
            }
        }
        private void LoadSomeData()
        {
            this.someData = "Hello world";
        }
    }
