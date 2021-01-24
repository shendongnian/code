    public class TestClass
    {
        private static Dictionary<string, Person> peopleList;
    
        public static TestClass()
        {
            peopleList = new Dictionary<string, Person>();
        }
        public static int AddPerson(Person p)
        {
            peopleList.Add(p.Name, p);
            return peopleList.Count;
        }    
    }
