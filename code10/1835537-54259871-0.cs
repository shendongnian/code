    public interface IPersonRepository
    {
        void AddPerson(Person person);
        IEnumerable<Person> GetPeople();
    }
    public class PersonService
    {
        private static readonly IPersonRepository _repo;
        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }
        public void AddPerson(Person person)
        {
            var people = _repo.GetPeople();
            if(people.Select(p=>p.LastName).Contains(person.LastName))
            {
                 // person exists
            }
            _repo.AddPerson(person);
        }
    }
    public class PersonServiceTests
    {
         public void ShouldNotAddPersonIfExists()
         {
             var mockRepo = new Mock<IPersonRepository>();
             mockRepo.Set(r => r.GetPeople()).Returns(new[]{new Person(firstName, lastName), new Person(otherName, lastName));
             var service = new PersonService(mockRepo.Object);
             /// try add and check assertions or exceptions thrown
         }
    }
