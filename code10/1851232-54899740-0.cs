    internal class Program
    {
        private static void Main(string[] args)
        {
            var p = new Person
            {
                Name = "Mark",
                Address = //<<<<<<<< HERE
                {
                    Number = 3,
                    Street = "Long street"
                }
            };
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public int Number { get; set; }
        public string Street { get; set; }
    }
