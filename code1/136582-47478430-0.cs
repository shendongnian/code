    class Program
    {
        static void Main()
        {
            int[] number = new int[] {5, 5, 6, 7};
            int sum = 0;
            for (int i = 0; i <number.Length; i++)
            {
                sum += number[i];
            }
            Console.WriteLine(sum);
        }
    }
