    public class Person
    {
        public int Id {get; set;}
        public string Name {get; set;}
    
        public IList<PersonPerson> _relatedPersons;
    
        public ReadOnlyCollection<PersonPerson> RelatedPersons
        {
            get
            {
               // The RelatedPersons property is mapped with NHibernate, but
               // using its backed field _relatedPersons (can be done using the 
               // access attrib in the HBM.
               // I prefer to expose the collection itself as a readonlycollection
               // to the client, so that RelatedPersons have to be added through
               // the AddRelatedPerson method (and removed via a RemoveRelatedPerson method).
               return new List<PersonPerson) (_relatedPersons).AsReadOnly();
            }
        }
        public void AddRelatedPerson( Person p, RelationType relatesAs )
        {
           ...
        }
    
    }
