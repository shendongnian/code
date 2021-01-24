    public class MovieInfo
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Version { get; set; }
        public static bool TryParse(string input, out MovieInfo result)
        {
            result = null;
            if (input == null) return false;
            var parts = input.Split(',');
            int version;
            if (parts.Length == 3 &&
                int.TryParse(parts[2].Trim().TrimStart('v'), out version))
            {
                result = new MovieInfo
                {
                    Name = parts[0],
                    Author = parts[1],
                    Version = version
                };
            }
            return result != null;
        }
        public override string ToString()
        {
            return $"{Name} (v{Version}) - {Author}";
        }
    }
