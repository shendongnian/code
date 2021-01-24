    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(null);
            person.PrintName();
        }
    }
    class Person
    {
        private string Name { get; set; }
        public Person(string name)
        {
            this.Name = name ?? "My name can't be null";
        }
        public void PrintName()
        {
            Console.WriteLine(this.Name);
        }
    }
