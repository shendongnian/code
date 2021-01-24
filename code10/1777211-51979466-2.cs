     class Program
        {
            static void Main(string[] args)
            {
                var elements = new Element[]
                {
                    new Element
                    {
                        TimeStamp = new DateTime(2018,5,1),
                        Name = "Prop1",
                        Value = 5,
                    },
                     new Element
                    {
                        TimeStamp = new DateTime(2018,5,7),
                        Name = "Prop1",
                        Value = 9,
                    },
                      new Element
                    {
                        TimeStamp = new DateTime(2018,5,1),
                        Name = "Prop2",
                        Value = 8,
                    },
                       new Element
                    {
                        TimeStamp = new DateTime(2018,5,7),
                        Name = "Prop2",
                        Value = 11,
                    },
                        new Element
                    {
                        TimeStamp = new DateTime(2018,5,1),
                        Name = "Prop3",
                        Value = 18,
                    },
                         new Element
                    {
                        TimeStamp = new DateTime(2018,5,7),
                        Name = "Prop3",
                        Value = 18,
                    },
                };            
                var pivot = from line in elements
                group line by line.TimeStamp into g
                select new { g.Key, Props=g.Select(el=>new { el.Name, el.Value }).ToArray(), Total = g.Sum(line => line.Value) };
                int propCount = pivot.Max(line => line.Props.Count());
                string[] props = pivot.SelectMany(p => p.Props, (parent, c) => c.Name).Distinct().ToArray();
                Console.Write($"Date\t");
                for (int i = 0; i < propCount; i++)
                {
                    Console.Write($"{props[i]}\t");
                }
                Console.Write($"Total");
                Console.WriteLine();
    
                foreach (var pivotLine in pivot)
                {
                    Console.Write($"{pivotLine.Key.ToShortDateString()}\t");
                    for (int i = 0; i < propCount; i++)
                    {
                        Console.Write($"{pivotLine.Props.FirstOrDefault(p=>p.Name==props[i])?.Value}\t");
                    }
                    Console.Write($"{pivotLine.Total}\t");
                    Console.WriteLine();
                }
            }
    
            class Element
            {
                public DateTime TimeStamp { get; set; }
                public string Name { get; set; }
    
                public int Value;
            }
