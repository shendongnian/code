     static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < 10000000; i++)
            {
                s.Append( i.ToString());
            }
            Console.Write("End");
            Console.Read();
        }
