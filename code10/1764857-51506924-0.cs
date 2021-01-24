    public class Animal
    {
        public string Name { get; set; }
        public bool HasLegs { get; set; }
        public bool IsFoo { get; set; }
        public string FooLegs { get; set; }
    }
    private static string legsString(bool hasLegs)
        {
            return hasLegs ? "Has Legs" : "Has No Legs";
        }
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>()
            {
                new Animal()
                {
                    Name = "Foo",
                    HasLegs = true
                },
                new Animal()
                {
                    Name = "Kangaroo",
                    HasLegs = true
                },
                new Animal()
                {
                    Name = "Snake",
                    HasLegs = false
                }
            };
            var fooAnimals = animals.Select(s => new Animal
            {
                Name = s.Name,
                HasLegs = s.HasLegs,
                IsFoo = (s.Name == "Foo" && s.HasLegs),
                FooLegs = $"{s.Name} {legsString(s.HasLegs)}"
            }).AsQueryable<Animal>();
        }
    }
