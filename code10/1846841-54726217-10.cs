    private static void Print(char[,] env)
    {
        Console.Clear();
        for (int i = 0; i < env.GetLength(0); i++) {
            for (int j = 0; j < env.GetLength(1); j++) {
                Console.Write(env[i, j]);
            }
            Console.WriteLine();
        }
        Thread.Sleep(1000);
    }
