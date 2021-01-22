        static IEnumerable<string> Lines(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
        }
