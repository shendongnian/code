    static void Main(string[] args)
        {
            var properties = typeof(DemoPerson).GetProperties();
            foreach(var property in properties)
            {
                Console.WriteLine($"Property: {property.Name}\tType: {property.PropertyType}");
            }
            Console.ReadLine();
        }
        public class DemoPerson
        {
            public Guid Id { get; set; }
            public string Name { get; set; }            
            public List<DemoAddress> Addresses { get; set; }            
        }
        public class DemoAddress
        {
            public string City { get; set; }            
        }
