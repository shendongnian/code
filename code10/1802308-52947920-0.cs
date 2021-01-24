    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<(ushort id, ushort sc), Timepoint[]> timepoints = new Dictionary<(ushort id, ushort sc), Timepoint[]>();
            timepoints.Add((1, 1), new Timepoint[] { new Timepoint(1, "1,1,1"), new Timepoint(1, "1,1,2"), new Timepoint(1, "1,1,3") });
            timepoints.Add((1, 2), new Timepoint[] { new Timepoint(1, "1,2,1"), new Timepoint(1, "1,2,2"), new Timepoint(1, "1,2,3") });
            timepoints.Add((2, 1), new Timepoint[] { new Timepoint(1, "2,1,1"), new Timepoint(1, "2,1,2"), new Timepoint(1, "2,1,3") });
            timepoints.Add((2, 2), new Timepoint[] { new Timepoint(1, "2,2,1"), new Timepoint(1, "2,2,2"), new Timepoint(1, "2,2,3") });
            var test = timepoints
    .GroupBy(kvp => kvp.Key.id)
    .Select(grp => new { grp.Key, Values = grp.SelectMany(x => x.Value).ToArray() })
    .ToDictionary(x => x.Key, x => x.Values);
            Console.WriteLine("Hello World!");
        }
    }
    class Timepoint
    {
        public Timepoint(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
