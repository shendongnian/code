    static void Main(string[] args)
        {
            string s = "";
            for (int i = 0; i < 10000000; i++)
            {
                s += i.ToString();
            }
            Console.Write("End");
            Console.Read();
        }
