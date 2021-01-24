    private static void Main(string[] args)
        {
            var rollcall = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter something here. May be a number");
                var names = Console.ReadLine();
                if (string.IsNullOrEmpty(names))
                {
                    Console.WriteLine("No input captured. Do you want to exit ?. Press enter to exit.");
                    if (ConsoleKey.Enter == Console.ReadKey().Key)
                    {
                        break;
                    }
                }
                rollcall.Add(names);
                var number = rollcall.Count;
                if (number == 1)
                {
                    Console.WriteLine(" {0} likes your post.", rollcall[0]);
                    continue;
                }
                else if (number == 2)
                {
                    Console.WriteLine("{0} and {1} likes your post\n Press Enter to Exit", rollcall[0], rollcall[1]);
                    if (ConsoleKey.Enter == Console.ReadKey().Key)
                    {
                        break;
                    }
                    continue;
                }
                else if (number == 3)
                {
                    Console.WriteLine("{0}, {1}, and {2} other likes your post.\n Press Enter to Exit", rollcall[0], rollcall[1], number - 2);
                    if (ConsoleKey.Enter == Console.ReadKey().Key)
                    {
                        break;
                    }
                    continue;
                }
                else if (number >= 4)
                {
                    Console.WriteLine("{0}, {1}, and {2} others like your post.\n Press Enter to Exit", rollcall[0], rollcall[1], number - 2);
                    if (ConsoleKey.Enter == Console.ReadKey().Key)
                    {
                        break;
                    }
                    continue;
                }
            }
            Console.WriteLine("Done !");
        }
