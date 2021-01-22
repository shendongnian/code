        {
            Console.Write("Please input your comment: ");
            string str = Console.ReadLine();
            string[] str2 = str.Split(' ');
            replaceStringWithString(str2);
            Console.ReadLine();
        }
        public static void replaceStringWithString(string[] word)
        {
            string[] strArry1 = new string[] { "good", "bad", "hate" };
            string[] strArry2 = new string[] { "g**d", "b*d", "h**e" };
            for (int j = 0; j < strArry1.Count(); j++)
            {
                for (int i = 0; i < word.Count(); i++)
                {
                    if (word[i] == strArry1[j])
                    {
                        word[i] = strArry2[j];
                    }
                    Console.Write(word[i] + " ");
                }
            }
        }
