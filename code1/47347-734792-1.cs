    public class Person
    {
        private string _name = "";
        private List<String> oldnames = new ArrayList();
    
        public string Name
        {
            get { return _name; }
            set 
            {
               oldnames.Add(_name);
               _name = value; 
            }
        }
    
        public Person(string name)
        {
            _name = name; //should I use the property or field here?
        }
    }
