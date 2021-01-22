       List<string> quotelist=File.ReadAllLines(filename).ToList();
                string fristitem= quotelist[0];
                quotelist.RemoveAt(0);
                File.WriteAllLines(filename, quotelist.ToArray());
                return fristitem;
