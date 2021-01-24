    class AThing
    {
        public string Name { get; set; }
        public int id { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, AThing> dict = new Dictionary<int, AThing>();
            for (var c = 0; c < 100; c++)
            {
                DateTime nowTime = DateTime.Now;
                for (var i = 0; i < 1000000; i++)
                {
                    var thing = new AThing { id = (c * 1000000) + i, Name = $"Item {(c * 1000000) + i}" };
                    dict.Add(thing.id, thing);
                }
                var timeTaken = DateTime.Now - nowTime;
                Console.WriteLine($"pass number {c} took {timeTaken.Milliseconds} milliseconds");
            }
        }
    }
