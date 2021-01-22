        static void Main(string[] args)
        {
            string content = File.ReadAllText(args[0]);
            Regex openTag = new Regex("<([/]?)RemovalTarget([^>]*)>", RegexOptions.Multiline);
            string cleanContent = openTag.Replace(content, string.Empty);
            File.WriteAllText(args[1], cleanContent);
        }
