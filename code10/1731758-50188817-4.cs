    class FoundIndex
    {
        public bool Found;
        public int LastFoundPosition = -1;
    }
    static void Main()
    {
        var longNames = new string[] 
                        { 
                           "PRODUCT MANAGER OFFICE",
                           "GYPSUM MINING OFFICE",
                           "THE PRODUCTION of MANAGEMENT for OFFICES",
                           "PRODUCT PACKING PLANT",
                           "PRODUCT OFFICE MANAGER"
                        };
        string shortName = "P.M.Off";
        var charsToSearchFor = shortName.Where(c => char.IsLetter(c)).Select(c => char.ToLower(c)).ToArray();
        foreach (var longName in longNames)
        {
            var charMatches = new List<FoundIndex>();
            var wordMatches = new List<FoundIndex>();
            var words = longName.Split();
            for (int i = 0; i < charsToSearchFor.Count(); ++i)
            {
                charMatches.Add(new FoundIndex() { LastFoundPosition = 0 });
                if (charMatches[i].Found)
                {
                    continue;
                }
                for (int j = wordMatches.LastIndexOf(wordMatches.LastOrDefault(t => t.Found)); j < words.Length; ++j)
                {
                    if(j == -1)
                    {
                        //skip if we're just starting out and haven't found anything yet
                        continue; 
                    }
                    if (j >= wordMatches.Count())
                    {
                        wordMatches.Add(new FoundIndex());
                    }
                    if (wordMatches[j].Found && wordMatches[j].LastFoundPosition +1 == words[j].Length)
                    {
                        continue; //skip this word if it's been fully searched
                    }
                    var matchPosition = words[j].ToLower().Substring(wordMatches[j].LastFoundPosition + 1).IndexOf(charsToSearchFor[i]);
                    charMatches[i].Found = matchPosition > -1;
                    if (charMatches[i].Found)
                    {
                        wordMatches[j].Found = true;
                        charMatches[i].LastFoundPosition = j;
                    }
                    if (wordMatches[j].Found)
                    {
                        if (matchPosition > wordMatches[j].LastFoundPosition)
                        {
                            //save the position so we can resume searching her for the next char
                            wordMatches[j].LastFoundPosition = matchPosition; 
                        }
                        else if(matchPosition == -1)
                        {
                            //we already matched a char to this word but couldn't match the next char so consider this word fullySearched
                            wordMatches[j].LastFoundPosition = words[j].Length - 1; 
                        }
                    }
                    if (charMatches[i].Found)
                    {
                        break;
                    }
                }
            }
            var match = charMatches.All(t => t.Found);
            Console.WriteLine($"{longName} : {match}");
        }
        Console.ReadKey();
    }
