    static int GetNumForPalindrome(string str)
        {
            int count = 0;
            for (int start = 0, end = str.Length - 1; start < end; ++start)
            {
                if (str[start] != str[end])
                    ++count;
                else --end;
            }
            return count;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(GetNumForPalindrome(Console.ReadLine()).ToString());
                
            }
            
        }
