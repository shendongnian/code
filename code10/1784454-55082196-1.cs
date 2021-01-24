    public static void Main(string[] args)
        {
            int count = 0;
            inputSteream:
            Console.WriteLine("Enter your  sentence: ");
            string sentence = Console.ReadLine();
            while (!String.IsNullOrEmpty(sentence) && sentence.Length >= 6)
            {
                foreach (var item in sentence.Split(' '))
                {
                    if (item.Length >= 6)
                    {
                        Console.WriteLine("The sentece is {0}", item);
                        count++;
                        break;
                    }
                    
                }
                break;
            }
            if (count == 0)
            {
                goto inputSteream;
            }
            Console.ReadKey();
        }
