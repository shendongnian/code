    string input = "aaaaabbcbbbcccddefgg";
            char[] chars = input.ToCharArray();
            Dictionary<char, int> dictionary = new Dictionary<char,int>();
            foreach (char c in chars)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary[c] = 1; //
                }
                else
                {
                    dictionary[c]++;
                }
            }
            foreach (KeyValuePair<char, int> combo in dictionary)
            {
                if (combo.Value > 1) //If the vale of the key is greater than 1 it means the letter is repeated
                {
                    Console.WriteLine("Letter " + combo.Key + " " + "is repeated " + combo.Value.ToString() + " times");
                }
            }
