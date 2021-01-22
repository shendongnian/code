    public static string Reverse(string word)
            {
                int index = word.Length - 1;
                string reversal = "";
                //for each char in word
                for (int i = index; index >= 0; index--)
                {
                    reversal = reversal + (word.Substring(index, 1));
                    Console.WriteLine(reversal);
                }
                return reversal;
            }
