    class Program
    {
        static void Main(string[] args)            
        {
            ulong sum, gh = 0;
            for (ulong i = 2; i <= 355000; i++)
            {
                string s = Convert.ToString(i);
                sum = 0;
                int ddd = s.Length;
                for (int j = 0; j < ddd; j++)
                {
                    //sum +=(int)Math.Pow(Convert.ToInt32(s[j]), 4);
                    ulong g = Convert.ToUInt64(Convert.ToString(s[j]));
                    sum = sum + (ulong)Math.Pow(g, 5);
                }
                // Console.WriteLine(sum);
                if (sum == i)
                {
                    gh += i;
                }
            }
            Console.WriteLine(gh);
               
            Console.ReadKey();
        }
    }
