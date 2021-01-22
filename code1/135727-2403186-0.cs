        static void Compare(string alpha, string beta)
        {
            HashSet<string> alphaContent = new HashSet<string>();
            StreamReader reader = new StreamReader(alpha);
            while (!reader.EndOfStream)
                alphaContent.Add(reader.ReadLine());
            reader.Close();
            reader = new StreamReader(beta);
            while (!reader.EndOfStream)
            {
                string fullpath = reader.ReadLine();
                string filename = Path.GetFileNameWithoutExtension(fullpath);
                if (alphaContent.Contains(filename))
                {
                    File.AppendAllText(@"C:\array_tech.txt", fullpath);
                }
            }
            reader.Close();
        }
