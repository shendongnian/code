            string file = @"C:\file.txt";
            string strToProcess = "fkdfdsfdflkdkfk@dfsdfjk72388389@kdkfkdfkkl@jkdjkfjd@jjjk@";
            string[] lines = strToProcess.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line + "@");
                }
            }
