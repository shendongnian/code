    class Program
    {
        static void Main(string[] args)
        {
            double sum=0;
            for (int i = 1000; i <=1000; i++)
            {
                double pow = Math.Pow(2, i);
                string power = pow.ToString();
                for (int j = 0; j < power.Length; j++)
                {
                     sum = sum+pow % 10;
                     StringBuilder t = new StringBuilder(pow.ToString());
                     int len = t.Length;
                     if (len != 1)
                     {
                         t.Remove(len - 1, 1);
                     }
                     pow = Convert.ToDouble(t.ToString());
                }
                 Console.WriteLine(sum);
                    Console.WriteLine();
                
            }
        }
    }
