    class Program
    {
        static void Main()
        {
            Console.Clear();
            float rows = GetFloatInput("Please Enter Number Of Rows: ");
            int cols = GetIntInput("Please Enter Number Of Columns: ");
            int[,] rectangleArray = CreateRectangleArray(rows, cols);
            SumRows(rectangleArray, rows, cols);
            Console.ReadLine();
        }
        
        static int[,] CreateRectangleArray(float rows, int cols)
        {
            int[,] result = new int[(int)rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine();
                    result[i, j] = GetIntInput($"Please Enter Matrix Element {i+1}, {j+1}");
                }
            }
            return result;
        }
        static void SumRows(int[,] arr, float rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                int result = 0;
                for (int j = 0; j < cols; j++)
                {
                    result += arr[i, j];
                }
                Console.WriteLine("The Sum of row No {0} = {1}", i, result);
            }
        }
        private static float GetFloatInput(string message)
        {
            Console.WriteLine(message);
            float result = 0;
            while (!float.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Failed to parse your input. Make sure it is numeric. Please try again:");
            }
            return result;
        }
        private static int GetIntInput(string message)
        {
            Console.WriteLine(message);
            int result = 0;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Failed to parse your input. Make sure it is an integer. Please try again:");
            }
            return result;
        }
    }
