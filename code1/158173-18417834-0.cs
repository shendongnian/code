    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Convert.ToString(Console.ReadLine());
            for (int i = 97; i < 123; i++)
            {
                string s2 = Convert.ToString(Convert.ToChar(i));
                CountStringOccurrences(s1, s2);
            }
            Console.ReadLine();
        }
        public static void CountStringOccurrences(string text, string pattern)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            if (count != 0)
            {
                Console.WriteLine("{0}-->{1}", pattern, count);
            }
        }
    }
}
