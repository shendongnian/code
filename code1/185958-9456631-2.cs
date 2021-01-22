    public class Person
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (!IsReadOnly) _firstName = value;
                else throw new AccessViolationException("Object is read-only.");
            }
        }
    
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (!IsReadOnly) _lastName = value;
                else throw new AccessViolationException("Object is read-only.");
            }
        }
    
        internal virtual bool IsReadOnly { get { return false; } }
    
        public ReadOnlyPerson AsReadOnly()
        {
            return new ReadOnlyPerson(this);
        }
    
        public class ReadOnlyPerson : Person
        {
            private Person _person;
            internal override bool IsReadOnly { get { return true; } }
    
            internal ReadOnlyPerson(Person person) // Contructor
            {
                this._person = person;
            }
        }
    }
