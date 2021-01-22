        public static IEnumerable<string> GetrandomLines()
        {
            string filepath = "..\\..\\data.txt";
            var readTextFile = ReadLines(filepath);
            var codeGroup = readTextFile.GroupBy(line => line.Substring(line.Length - 2));
            Random rnd = new Random(DateTime.Now.Millisecond);
            foreach (var item in codeGroup)
            {
                foreach (var s in item.Skip(rnd.Next(item.Count())).Take(1))
                    yield return s;
                foreach (var s in item.Skip(rnd.Next(item.Count())).Take(1))
                    yield return s;
            }
        }
