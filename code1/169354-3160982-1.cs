        public IEnumerable<Byte[]> ReadFile(String fileName)
        {
            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    while (reader.Peek() >= 0)
                    {
                        String line = reader.ReadLine();
                        yield return System.Text.Encoding.Default.GetBytes(line);
                    }
                }
            }
        }
