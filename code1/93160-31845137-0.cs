        private string[] GetLines(string text)
        {
            List<string> lines = new List<string>();
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms);
                sw.Write(text);
                sw.Flush();
                ms.Position = 0;
                string line;
                using (StreamReader sr = new StreamReader(ms))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                sw.Close();
            }
            return lines.ToArray();
        }
