    class Program
    {
        static void Main(string[] args)
        {
            List<class1> data = new List<class1>
            {
                new class1
                {
                    Id= "ABCD",
                    location = "ABCD Location",
                    TypeId="Mango",
                    free=3,
                    total=6
                },
                new class1
                {
                    Id="ABCD",
                    location="ABCD Location",
                    TypeId="Apple",
                    free=4,
                    total=8
                }
            };
            var result = data.GroupBy(g => new
            {
                locationId = g.Id,
                location = g.location
            }).Select(s => new class2
            {
                locationId=s.Key.locationId,
                location=s.Key.location,
                Fruits=s.Select(f=>new Fruits
                {
                    Free=f.free,
                    Total=f.total,
                    TypeId=f.TypeId
                }).ToList()
            }).ToList();
            Console.ReadLine();
        }
        public class class1
        {
            public string Id { get; set; }
            public string location { get; set; }
            public string TypeId { get; set; }
            public int free { get; set; }
            public int total { get; set; }
        }
        public class class2
        {
            public string locationId { get; set; }
            public string location { get; set; }
            public string deviceTypeId { get; set; }
            public List<Fruits> Fruits { get; set; }
        }
        public class Fruits
        {
            public string TypeId { get; set; }
            public int Free { get; set; }
            public int Total { get; set; }
        }
    }
