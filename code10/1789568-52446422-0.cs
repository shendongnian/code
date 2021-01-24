    public class Human : IHuman
    {
        public Human(string name, string job)
        {
            Name = name;
            Job = job;
        }
        public string Name { get; set; }
        public string Job { get; set; }
        public string getName()
        {
            return Name;
        }
    }
