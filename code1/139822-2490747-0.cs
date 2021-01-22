        static void Main(string[] args)
        {
            var list = new List<Mammal>();
            list.Add(new Person { Name = "Filip", DOB = DateTime.Now });
            list.Add(new Person { Name = "Peter", DOB = DateTime.Now });
            list.Add(new Person { Name = "Goran", DOB = DateTime.Now });
            list.Add(new Person { Name = "Markus", DOB = DateTime.Now });
            list.Add(new Dog { Name = "Sparky", Breed = "Unknown" });
            list.Add(new Dog { Name = "Little Kid", Breed = "Unknown" });
            list.Add(new Dog { Name = "Zorro", Breed = "Unknown" });
            foreach (var item in list)
                Console.WriteLine(item.Speek());
            list = ReCalculateDOB(list);
            foreach (var item in list)
                Console.WriteLine(item.Speek());
        }
