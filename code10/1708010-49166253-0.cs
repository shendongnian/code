    public string Replacement(string input, string replacement)
            {
                string[] words = input.Split(' ');
                int barIndex = 0;
                string result = string.Empty;
    
                for (int i = 0; i < words.Length; i++)
                {
                    if(words[i].Contains('/'))
                    {
                        barIndex = Reverse(words[i]).LastIndexOf('/') + 1;
                        int removeLenght = words[i].Substring(barIndex).Length;
                        words[i] = Reverse(words[i]);
                        words[i] = words[i].Remove(barIndex, removeLenght);
                        words[i] = words[i].Insert(barIndex, Reverse(replacement));
                        string ToReverse = words[i];
                        words[i] = Reverse(ToReverse);
    
                        break;
                    }
                }
    
                for(int i = 0; i < words.Length; i++)
                {
                    result += words[i] + " ";
                }
    
                result = result.Remove(result.Length - 1);
    
                return result;
            }
    
            public string Reverse(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
