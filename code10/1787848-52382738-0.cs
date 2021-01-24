    public class Item
    {
        public string Name { get; set; }
        public string Href { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<Item>
            {
                new Item { Name="1", Href="" },
                new Item { Name="1", Href="b" },
                new Item { Name="2", Href="c" },
                new Item { Name="2", Href="" },
                new Item { Name="2", Href="" },
            };
            var results = data.OrderBy(d => d.Name).ThenByDescending(d => d.Href).GroupBy(d => d.Name).Select(g => g.First());
            foreach (var result in results)
            {
                Console.WriteLine(result.Name + ", " + result.Href);
            }
            Console.ReadLine();
        }
    }
