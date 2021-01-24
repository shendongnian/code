          static void Main(string[] args)
        {
            Console.Write("Input a string : ");
            string str1 = Console.ReadLine();
            while (str1.Length > 0)
            {
                Console.Write(str1[0] + ":");
                int count = 0;
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[0] == str1[i])
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
                str1 = str1.Replace(str1[0].ToString(), string.Empty);
            }
            Console.Read();
        }
