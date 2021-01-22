            static string FourtyLetterWords(string s)
            {
                var splitString = GetWords(s);
                return string.Join("", splitString.Select(u => u.Count() >= 40 ? u.Substring(0, 40) : u));
            }
    
            private static List<string> GetWords(string s)
            {
                var stringList = new List<string>();
                StringBuilder currentWord = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    if(char.IsLetter(s[i]))
                    {
                        currentWord.Append(s[i]);
                    }
                    else
                    {
                        stringList.Add(currentWord.ToString());
                        currentWord.Clear();
                        stringList.Add(s[i].ToString());
                    }
                }
                return stringList;
            }
