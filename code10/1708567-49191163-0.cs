    static void Main()
        {
            var a = new List<string> {
               "ID = Value",
               "id=value",
               "id      =    value"
            };
            var values = new List<string>();
            var ids = new List<string>();
            for (int i = 0; i < a.Count; i++)
            {
                (string value, string id) = SplitText(a[i]);
                values.Add(value);
                ids.Add(id);
            }
            Console.WriteLine($"Values -> {string.Join(", ", values)}, ID's -> {string.Join(", ", ids)}");
        }
        private static (string, string) SplitText(string inputText)
        {
            var tokens = inputText.Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
            return (tokens[0], tokens[1]);
        }
