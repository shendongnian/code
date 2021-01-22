            string pattern = @"(?<first>\w{3})\t*(?<second>\w*)\t*(?<third>\w*)\t*(?<fourth>\w*)";
            try
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Regex r = new Regex(pattern);
                    StringBuilder sBuilder = new StringBuilder();
                    Match m;
                    int i = 0;
                    for (m = r.Match(input); m.Success; m = m.NextMatch())
                    {
                        //sBuilder.Append(String.Format("Match[{0}]: ", i));
                        for (int j = 1; j < m.Length; j++)
                        {
                            sBuilder.Append(String.Format("{0} ", m.Groups[j].Value));
                        }
                        sBuilder.AppendLine("");
                        i++;
                    }
                    Console.WriteLine(sBuilder.ToString());
                }
                else
                {
                    Console.WriteLine("No match");
                    
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.Append("Error parsing: \"");
                sBuilder.Append(pattern);
                sBuilder.Append("\" - ");
                sBuilder.Append(e.ToString());
                Console.WriteLine(sBuilder.ToString());
            }
        }
