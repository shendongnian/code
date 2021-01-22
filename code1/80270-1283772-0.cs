    public class PersonLite : ReadOnlyBase<PersonLite>
    {
        public void Update(PersonFull person) { }
    }
    public class PersonFull : BusinessBase<PersonFull>
    {
        // blah blah
    }
