    class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] intArr = new int[100];
            for (int i = 0; i < intArr.Length; i++)
            {
                int num = rnd.Next(1, 1000);
                intArr[i] = num;
                Console.WriteLine(num);
            }
            Console.WriteLine();
            int maxNum = intArr.Max();
            Console.WriteLine("The max num is:" + maxNum);
            Console.ReadLine();
        }
    }
    
