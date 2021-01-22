    internal sealed class PersonFinder
    {
        public PersonFinder(int minAge, string region)
        {
            this.minAge = minAge;
            this.region = region;
        }
        private readonly int minAge;
        private readonly string region;
        public bool IsMatch(Person person)
        {
            return person.Age > minAge && person.Region == region;
        }
    }
    ...
    Person person = list.Find(new PersonFinder(minAge,region).IsMatch);
