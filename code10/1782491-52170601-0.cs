    static string GetSentencesContainMyWord(StreamReader file)
                {
                    int counter = 0;
                    string line;
                    var sb = new StringBuilder();
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("my"))
                            sb.Append(line + Environment.NewLine);
                        counter++;
                    }
                    return sb.ToString();
                }
