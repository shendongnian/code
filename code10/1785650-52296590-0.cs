                string[] lines = File.ReadAllLines(sPath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].IndexOf(";;") != -1)
                    {
                        lines[i] = lines[i].Insert(line.IndexOf(";;"), "xxx");
                    }
                }
                File.WriteAllLines(sPathTemp, lines);    
                
