        private static IEnumerable<string> GetUniqueWords(string phrase, string word, int amount)
        {
            //Clean up the string and get the words
            string[] words = Regex.Split(phrase.Replace(".","").Replace(",",""),@"\s+");
            //Find the first occurrence of the desired word (spec allows)
            int index = Array.IndexOf(words,word);
            //We don't wrap around the edges if the word is the first, 
            //we won't look before if last, we won't look after, again, spec allows
            int min = (index - amount < 0) ? 0 : index - amount;
            int max = (index + amount > words.Count() - 1) ? words.Count() - 1 : index + amount;
            //Add all the words to a list except the supplied one
            List<string> rv = new List<string>();
            for (int i = min; i <= max; i++)
            {
                if (i == index) continue;
                rv.Add(words[i]);
            }
            //Unique-ify the resulting list
            return rv.Distinct();
        }
    }
