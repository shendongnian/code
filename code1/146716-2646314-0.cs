    public class BrokenClass
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { Name = value; }  // <--- Whoops
        }
    }
