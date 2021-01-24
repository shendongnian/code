    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i + j  == 4)
                    {
                        arr[i, j] = j + 1;
                    }
                    else
                    {
                        arr[i, j] = 0;
                    }
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
