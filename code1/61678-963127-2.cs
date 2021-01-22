    public static class MyExtensions
    {
        public static IQueryable<Person> People(this IQueryable<Person> source)
        {
            return from person in source
                   select person;
        }
        public static IQueryable<Person> Crew(this IQueryable<Person>  source)
        {
            return from person in source
                   where person.type == crewMember
                   return person;
        }
        public static IQueryable<Person> IsApproved(this IQueryable<Person>  source)
        {
            return from person in source
                   where person.IsApproved == true
                   return person;
        }
    }
