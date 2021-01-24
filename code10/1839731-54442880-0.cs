    class Repere
    {
        public string Name { get; set; }
        public List<Operation> Operations { get; set; }
    }
    
    class Operation
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<Repere>
            {
                new Repere { Name = "Repere1", Operations = new List<Operation>
                {
                    new Operation { Id = 1, Quantity = 2 },
                    new Operation { Id = 2, Quantity = 1 },
                    new Operation { Id = 3, Quantity = 5 }
                }},
                new Repere { Name = "Repere1", Operations = new List<Operation>
                {
                    new Operation { Id = 1, Quantity = 2 },
                    new Operation { Id = 2, Quantity = 1 },
                    new Operation { Id = 4, Quantity = 2 }
                }},
            };
    
            var result = data.GroupBy(r => r.Name)
                .Select(gr => new
                {
                    Name = gr.Key,
                    Operations = gr.SelectMany(g => g.Operations)
                        .GroupBy(o => o.Id)
                        .Select(go => new { Id = go.Key, Quantity = go.Sum(o => o.Quantity)})
                });
    
            foreach (var r in result)
            {
                Console.WriteLine(r.Name);
                foreach (var o in r.Operations)
                {
                    Console.WriteLine($"\t{o.Id}\t{o.Quantity}");
                }
            }
    
            Console.ReadKey();
        }
    }
