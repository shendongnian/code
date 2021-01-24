    public abstract class PersonDecorator : Person
    {
        protected Person Person { get; }
        public PersonDecorator(Person person) => Person = person;
        public override string Name => Person.Name;
    }
