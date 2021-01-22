        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a count: ");
                string s = Console.ReadLine();
                int count;
                if (Int32.TryParse(s, out count))
                {
                    MaximalLFSR lfsr = new MaximalLFSR();
                    foreach (int i in lfsr.RandomIndexes(count))
                    {
                        Console.Write(i + ", ");
                    }
                }
                Console.WriteLine("Done.");
            }
        }
