    public static void Main()
    {
            string inputedString; 
            string reversedString;
            while (true)
            {
                inputedString = Console.ReadLine();
                reversedString = string.Empty;
                if (inputedString == "END")
                {
                    break;
                }
                for (int i = inputedString.Length - 1; i >= 0; i--)
                {
                    reversedString += inputedString[i];
                }
                if (reversedString == inputedString)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
