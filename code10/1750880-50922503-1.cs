    class Program
    {
        public class Connector
        {
            public Connector(double id, string name, double len, double height, double count)
            {
                Id = id;
                Name = name;
                Len = len;
                Height = height;
                Count = count;
            }
            public double Id { get; set; }
            public string Name { get; set; }
            public double Len { get; set; }
            public double Height { get; set; }
            public double Count { get; set; }
        }
        static void Main(string[] args)
        {
            var l = new List<Connector>
            {
                new Connector(1, "IZO", 1000, 200, 2),
                new Connector(2, "IZO", 1000, 200, 4),
                new Connector(3, "IZO", 600, 200, 5),
                new Connector(4, "IZO", 1000, 200, 2),
                new Connector(5, "IZO", 600, 180, 7),
                new Connector(6, "IZO", 600, 180, 3)
            };
            var sums = from c in l
                       group c by new { c.Name, c.Len, c.Height } into g
                       select new { g.First().Id, g.Key.Name, g.Key.Len, g.Key.Height, Count = g.Sum(x => x.Count) };
        }
    }
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/nXJht.png
