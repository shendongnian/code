        static void Main(string[] args)
        {
            int correct = 0;
            using (StreamReader sr = new StreamReader("C:\\quiz.txt"))
            {
                while (!sr.EndOfStream)
                {
                    Console.Clear();
                    for (int i = 0; i &lt; 5; i++)
                    {
                        String line = sr.ReadLine();
                        if (i &gt; 0)
                        {                            
                            if (line.Substring(0, 1) == "#") correct = i;
                            Console.WriteLine("{0}: {1}", i, line);
                        }
                        else
                        {
                            Console.WriteLine(line);
                        }
                    }                                       
                    for (; ; )
                    {
                        Console.Write("Select Answer: ");
                        ConsoleKeyInfo cki = Console.ReadKey();
                        if (cki.KeyChar.ToString() == correct.ToString())
                        {
                            Console.WriteLine(" - Correct!");
                            Console.WriteLine("Press any key for next question...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" - Try again!");
                        }
                    }
                }
            }
        }
