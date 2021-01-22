    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the Height of the Pyramid: ");
                int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    for (int j = n; j >= i; j--)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 1; k <= i; k++)
                    {
                        Console.Write("*");
                    }
                    for (int m = 2; m <= i; m++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } Console.Read();
        }
    }
}
