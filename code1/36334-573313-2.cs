        static void Main(string[] args)
        {
            int correct = 0;
            using (StreamReader sr = new StreamReader("C:\\quiz.txt"))
            {
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i &lt; 5; i++)
                    {
                        if (i &gt; 0)
                        {
                            String line = sr.ReadLine();
                            if (line.Substring(0, 1) == "#") correct = i;
                            Console.WriteLine("{0}: {1}", i, line);
                        }
                        else
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                    }                                       
                    for (; ; )
                    {
                        Console.Write("Select Answer: ");
                        ConsoleKeyInfo cki = Console.ReadKey();
                        if (cki.KeyChar.ToString() == correct.ToString())
                        {
                            Console.WriteLine(" - Correct!");
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
