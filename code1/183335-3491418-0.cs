     class Person
    {
         public string Name
         {
              get;
             protected set;
         }
        List<Person> Relatives
         {
            get;
            set;
         }
        public Person(string name)
        {
            this.Name = name;
            Relatives = new List<Person>();
        }
        public void AddRelative(Person Relative)
        {
            Relatives.Add(Relative);
        }
        public void PrintRelatives()
        {
            foreach (Person Relative in Relatives)
            {
                Console.WriteLine(Relative.Name);
            }
        }
        static void Main(string[] args)
        {
            Person jim = new Person("Jim");
            jim.AddRelative(new Person("James"));
            jim.AddRelative(new Person("Peter"));
            jim.AddRelative(new Person("Frank"));
            jim.PrintRelatives();
            Console.ReadLine();
        }
    }
