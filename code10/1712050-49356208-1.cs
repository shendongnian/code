    public List<string> GetUpperLetters(string input)
            {
                List<string> result = new List<string>();
                int index_0 = 0;
                string accum = string.Empty;
    
                //Convert string input to char collection 
                //and walk it one by one
                foreach (char c in input.ToCharArray())
                {
                    if(char.IsLetter(c) && char.IsUpper(c))
                    {
                        accum += c;
                        index_0++;
                        if(index_0 == 3)
                        {
                            index_0 = 0;
                            result.Add(accum);
                            accum = string.Empty;
                        }
                    }
                }
    
                return result;
            }
