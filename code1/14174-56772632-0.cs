             static void Main(string[] args)
            {
                string str = "";
                string reverse = "";
                Console.WriteLine("Enter the value to reverse");
                str = Console.ReadLine();
                int length = 0;
                length = str.Length - 1;
                while(length >= 0)
                {
                    reverse = reverse + str[length];
                    length--;
                }
                Console.Write("Reverse string is {0}", reverse);
                Console.ReadKey();
            }
