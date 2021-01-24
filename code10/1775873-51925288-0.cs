    class Program
    {
        static string add(params int[] number)
        {
            double sum = 0.0f;
            foreach (double n in number)
            {
                sum = sum + n;
            }
            return string.Format("{0:N2}" ,sum);
        }
        static void Main(string[] args)
        {
            // passing three parameters
            Program conv = new Program();
            Console.Write("The sum of the given number is: ");
            Console.Write(add(1, 2, 3));
    
            Console.ReadLine();
        }
    }
