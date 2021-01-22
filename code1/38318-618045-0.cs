    public class Person
    {
        public int Id {get; set;}
        public string Name {get; set;}
    
        public IList<PersonPerson> _relatedPersons;
    
        public IList<PersonPerson> RelatedPersons
        {
            get
            {
               ....
            }
        }
    
    }
