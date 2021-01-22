        public static IEnumerable<string> readFile()
        {
            using (StreamReader reader = new StreamReader(@"c:\test.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    yield return line;
                    line = reader.ReadLine();
                }
                reader.Close();
            }
        }
