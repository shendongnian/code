    class ReverseString
        {
            static void Main(string[] args)
            {
                int i;
                string Temp = string.Empty;
                string Str;
                Console.WriteLine("Enter string");
                Str = Console.ReadLine();
                int Prev = Str.Length - 1;
                for (i = Str.Length - 1; i >= 0; i--)
                {
                    if (Str[i] == ' ' || i == 0)
                    {
                        if (i == 0)
                            Temp += Str[i];
                        for (int j = i + 1; j <= Prev; j++)
                        {
                            Temp += Str[j];
                        }
    
                        Temp += ' ';
                        Prev = i - 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine(Temp);
            }
        }
    }
