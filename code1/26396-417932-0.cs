    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    enum Gender { Male, Female, Unknown }
    class Record
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Score { get; set; }
    }
    static class Program
    {
        static IEnumerable<string> ReadLines(string path)
        {
            using (var reader = File.OpenText(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        static IEnumerable<Record> Parse(string path)
        {
            foreach (string line in ReadLines(path))
            {
                string[] segments = line.Split(',');
                Gender gender;
                switch(segments[1]) {
                    case "m": gender = Gender.Male; break;
                    case "f": gender = Gender.Female; break;
                    default: gender = Gender.Unknown; break;
                }
                yield return new Record
                {
                    Name = segments[0],
                    Gender = gender,
                    Score = int.Parse(segments[2])
                };
            }
        }
        static void Main()
        {
            var males = from record in Parse("data.txt")
                        where record.Gender == Gender.Male
                        select record;
    
            Record best = null;
            foreach (var record in males)
            {
                if (best == null || record.Score > best.Score)
                {
                    best = record;
                }
            }
    
            Console.WriteLine("{0}: {1}", best.Name, best.Score);
        }
    }
