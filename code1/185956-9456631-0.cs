    public class Person
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    
        public ReadOnlyPerson AsReadOnly()
        {
            return new ReadOnlyPerson(this);
        }
    
        public class ReadOnlyPerson : Person
        {
            private Person _person;
    
            internal ReadOnlyPerson(Person person) // Contructor
            {
                this._person = person;
            }
    
            public override string FirstName
            {
                get { return this._person.FirstName; }
                set { throw new AccessViolationException("Object is read only."); }
            }
    
            public override string LastName
            {
                get { return this._person.LastName; }
                set { throw new AccessViolationException("Object is read only."); }
            }
        }
    }
