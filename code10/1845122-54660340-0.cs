    public class Person
    {
        public List<int> Vacations { get; set; }
        public string Name { get; set; }
    }
    public class Vacation
    {
        public List<string> People { get; set; }
        public int Day { get; set; }
        public int PeopleCount => People?.Count ?? 0;    
    }
