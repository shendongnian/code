    static void Main()
        {
            string[,] matrix = {
                                   { "aa", "aaa" },
                                   { "bb", "bbb" }
                               };
            int index = 0;
            foreach (string element in matrix)
            {
                if (index < matrix.GetLength(1))
                {
                    Console.Write(element);
                    if (index < (matrix.GetLength(1) - 1))
                    {
                        Console.Write(" ");
                    }
                    index++;
                }
                if (index == matrix.GetLength(1))
                {
                    Console.Write("\n");
                    index = 0;
                }
            }
