    public interface IInterface<T> where T : Contact
    {
        string Email { get; }
        string Phone { get; }
    }
    public class Person : Contact
    {
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    public class DetailsBase<T> : IInterface<T> where T : Contact
    {
        Contact _cont { get; set; }
        public string Email { get { return _cont.Email; } }
        public string Phone { get { return _cont.Phone; } }
        public DetailsBase(Contact cont)
        {
            _cont = cont;
        }
    }
    public class Contact
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class PersonDetails : DetailsBase<Person>
    {
        public PersonDetails(Person person) : base(person)
        {
        }
    }
