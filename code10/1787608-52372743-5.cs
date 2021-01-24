            List<String> narrowedWords = new List<String>();
            char letter = 'e';
            Dictionary<String, Int32> wordFamilies = new Dictionary<String, Int32>();
            foreach (String word in narrowedWords)
            {
                if (word.Contains(letter))
                {
                    var index = word.IndexOf(letter);
                    wordFamilies.Add(word, index);
                }
            }
