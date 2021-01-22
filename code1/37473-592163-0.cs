    public class Author : System.Attribute
    {
        private string name;
        public double version;
    
        public Author(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }
