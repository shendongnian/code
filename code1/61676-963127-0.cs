    public class Trip
    {
        public IQueryable<Person> People(this IQueryable source)
        {
            return from person in source
                   select person;
        }
        public IQueryable<Person> Crew(this IQueryable source)
        {
            return from person in source
                   where person.type == crewMember
                   return person;
        }
    }
