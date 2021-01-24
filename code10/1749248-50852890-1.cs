    public class TestClass
    {
        private Dictionary<string, Person> peopleList;
    
        public TestClass()
        {
            peopleList = new Dictionary<string, Person>();
        }
        public int AddPerson(Person p)
        {
            peopleList.Add(p.Name, p);
            return peopleList.Count;
        }    
    }
