     public static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            while (!String.IsNullOrEmpty(sentence)&& sentence.Length >= 6)
            {
                if (sentence.Length > 6)
                {
                    int count = 0;
                    foreachLoop:
                    foreach (var item in sentence.Split(' '))
                    {
                        if (item.Length >= 6)
                        {
                            Console.WriteLine("The sentece is {0}", item);
                            count++;
                            break;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Enter your desired sentence again: ");
                        sentence = Console.ReadLine();
                        goto foreachLoop;
                    }
                }
                else { break; }
                sentence = Console.ReadLine();
            }
            Console.ReadKey();
        }
