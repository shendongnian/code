     class Program
        {
            static void Main(string[] args)
            {
                bool[] doesExists = new bool[256];
                String st = Console.ReadLine();
                StringBuilder sb = new StringBuilder();
                foreach (char ch in st)
                {
                    if (!doesExists[ch])
                    {
                        sb.Append(ch);
                        doesExists[ch] = true;
                    }
                }
                Console.WriteLine(sb.ToString());
