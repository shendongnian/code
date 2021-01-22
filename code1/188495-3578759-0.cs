    public static class PersonFactory
    {
        public static Person CreatePerson()
        {
            return new Person();
        }
        public static Employee CreateEmployee()
        {
            return new Employee();
        }
        public static Pilot CreatePilot()
        {
            return new Pilot();
        }
        public static T CreatePerson<T>()
            where T : Person
        {
            return (T)CreatePerson(typeof(T));
        }
        public static Person CreatePerson(Type type)
        {
            if (type == typeof(Person))
                return CreatePerson();
            else if (type == typeof(Employee))
                return CreateEmployee();
            else if (type == typeof(Pilot))
                return CreatePilot();
            else
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Unrecognized type [{0}]", type.FullName), "type");
        }
        public static Person CreatePerson(string typeOfPerson)
        {
            switch (typeOfPerson)
            {
                case "Employee":
                    return CreateEmployee();
                case "Pilot":
                    return CreatePilot();
                default:
                    return CreateEmployee();
            }
        }
    }
    class UsageExample
    {
        Person GetPerson()
        {
            Pilot p;
            p = (Pilot)PersonFactory.CreatePerson("Pilot"); // this code already knows to expect a Pilot, so why not just call CreatePilot or CreatePerson<Pilot>()?
            p = PersonFactory.CreatePilot();
            p = PersonFactory.CreatePerson<Pilot>();
            return p;
        }
        Person GetPerson(Type personType)
        {
            Person p = PersonFactory.CreatePerson(personType);
            // this code can't know what type of person was just created, because it depends on the parameter
            return p;
        }
        void KnowledgableCaller()
        {
            Type personType = typeof(Pilot);
            Person p = this.GetPerson(typeof(Pilot));
            // this code knows that the Person object just returned should be of type Pilot
            Pilot pilot = (Pilot)p;
            // proceed with accessing Pilot-specific functionality
        }
        void IgnorantCaller()
        {
            Person p = this.GetPerson();
            // this caller doesn't know what type of Person object was just returned
            // but it can perform tests to figure it out
            Pilot pilot = p as Pilot;
            if (pilot != null)
            {
                // proceed with accessing Pilot-specific functionality
            }
        }
    }
