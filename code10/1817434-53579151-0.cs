    string myString = Console.ReadLine();
            char[] charStr = new char[str.Length];
            int k = charStr.Length - 1;
            for (int i=0;i<charStr.Length;i++)
            {
                int j = k;
                while (j>=0)
                {
                    charStr[j] = str[i];
                    j--;
                }
                k--;
            }
            foreach (char item in charStr)
            {
                Console.Write(item);
            }
            Console.WriteLine();
