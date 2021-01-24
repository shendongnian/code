    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                List<Client> clients = new List<Client>();
                int lineNumber = 0;
                while((line = reader.ReadLine()) != null)
                {
                    if (++lineNumber > 1)
                    {
                        clients.Add(new Client(line));
                    }
                }
            }
        }
        public class Client
        {
            public long size { get; set; }
            public string client { get; set; }
            public string ssflags { get; set; }
            public string group { get; set; }
            public string flags { get; set; }
            public DateTime date { get; set; }
            public string level { get; set; }
            public string volume { get; set; }
            public DateTime completed { get; set; }
            public string name { get; set; }
            public Client(string line)
            {
                string pattern = @"^\s*(?'size'[^\s]+)\s+(?'client'[^\s]+)\s+(?'ssflags'[^\s]+)\s+" +
                    @"(?'group'.*)\s+(?'flags'cr|cb)\s+(?'date'.+(AM|PM))\s+" +
                    @"(?'level'[^\s]+)\s+(?'volume'[^\s]+)\s+" +
                    @"(?'completed'.+(AM|PM))\s+(?'name'.*)";
                Match match = Regex.Match(line, pattern);
                size = long.Parse(match.Groups["size"].Value);
                client = match.Groups["client"].Value;
                ssflags = match.Groups["ssflags"].Value;
                group = match.Groups["group"].Value.Trim();
                flags = match.Groups["flags"].Value;
                date = DateTime.Parse(match.Groups["date"].Value);
                level = match.Groups["level"].Value;
                volume = match.Groups["volume"].Value;
                completed = DateTime.Parse(match.Groups["completed"].Value);
                name = match.Groups["name"].Value;
     
            }
        }
    }
