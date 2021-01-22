    public class Person
    {
        private string _name = "";
        private ArrayList oldnames = new ArrayList(); /* My java is REALLY rusty, forgive me */
    
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
