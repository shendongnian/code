                var text = new SortedDictionary<char, int>();
                var inputText = Console.ReadLine();
    
                foreach (var character in inputText)
                {
                    if (character == ' ')
                    {
                        continue;
                    }
    
                    if (text.ContainsKey(character))
                    {
                        text[character]++;
                    }
                    else
                    {
                        text.Add(character, 1);
                    }
                }
