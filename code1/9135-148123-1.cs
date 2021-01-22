    static class Program 
    {
        static void Main() 
        {
            var unsorted = new[] {
                new Person { BirthYear = 1948, Name = "Cat Stevens" },
                new Person { BirthYear = 1955, Name = "Kevin Costner" },
                new Person { BirthYear = 1952, Name = "Vladimir Putin" },
                new Person { BirthYear = 1955, Name = "Bill Gates" },
                new Person { BirthYear = 1948, Name = "Kathy Bates" },
                new Person { BirthYear = 1956, Name = "David Copperfield" },
                new Person { BirthYear = 1948, Name = "Jean Reno" },
            };
    
            Array.ForEach(unsorted, Console.WriteLine);
    
            Console.WriteLine();
            var unstable = (Person[]) unsorted.Clone();
            Array.Sort(unstable, (x, y) => x.BirthYear.CompareTo(y.BirthYear));
            Array.ForEach(unstable, Console.WriteLine);
    
            Console.WriteLine();
            var stable = (Person[]) unsorted.Clone();
            stable.StableSort((x, y) => x.BirthYear.CompareTo(y.BirthYear));
            Array.ForEach(stable, Console.WriteLine);
        }
    }
    sealed class Person 
    {
        public int BirthYear { get; set; }
        public string Name { get; set; }
    
        public override string ToString() {
            return string.Format(
                "{{ BirthYear = {0}, Name = {1} }}", 
                BirthYear, Name);
        }
    }
