    public class NHPersonRepository : IPersonRepository
    {
        ...
    
        public IList<Person> FindPersonsThatHaveARelationShipWithPerson( Person p )
        {
            ICriteria crit = _session.CreateCriteria <Person>();
            
            crit.AddAlias ("RelatedPersons", "r");
    
            crit.Add (Expression.Eq ("r.RelatedWithPerson", p));
    
            return crit.List();
    
        }
    }
