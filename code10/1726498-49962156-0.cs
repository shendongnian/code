    public static void PrintArray(int [,] arr)
    {
        for (int c = 0; c < arr.GetLength(1); c++)
        {
            for (int r = 0; r < arr.GetLength(0); r++)
            {
				 Console.Write(arr[r, c] + " ");
            }
			Console.WriteLine();
        }
    }
