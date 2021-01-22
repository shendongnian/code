    public class PersonLite : BusinessBase<PersonLite>
    {
        public PersonLite(PersonFull fullPerson)
        {
            //copy from fullPerson's properties or whatever
        }
    }
    public class PersonFull : BusinessBase<PersonFull>
    {
        public PersonFull(PersonLite litePerson)
        {
            //copy from litePerson's properties or whatever
        }
    }
