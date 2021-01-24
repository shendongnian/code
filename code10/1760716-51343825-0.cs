    public class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine($"{Environment.NewLine}");
            List<string> inputs = new List<string>
            {
                "ABC#99999",
                "9ABC#8",
                "9ABC",
                "9ABC#"
            };
            var groups = new List<Group>();
            foreach (string input in inputs)
            {
                string[] parts = input.Split("#", StringSplitOptions.RemoveEmptyEntries);
                var group = new Group
                {
                    Part1 = input
                };
                
                if (parts.Length == 2)
                {
                    group.Part1 = parts[0];
                    group.Part2 = parts[1];
                };
                groups.Add(group);
                Console.WriteLine($"Input: '{input}': {group}");
            }
            Console.ReadKey();
        }
    }
    public class Group
    {
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        /// <inheritdoc />
        public override string ToString()
        {
            return $"Part1: {Part1 ?? "null"}, Part2: {Part2 ?? "[null]"}";
        }
    }
