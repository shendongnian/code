    namespace MainClass
    {
        class Program
        {
            static void Main(string[] args)
            {
                int m = 3, n = 2, sum = 0;
    
                //Console.Write("The MxN matrix\n");
                //Console.Write("Enter the number of rows and columns of the matrix :\n");
                //Console.Write("Rows (M): ");
                //m = Convert.ToInt32(Console.ReadLine());
                //Console.Write("Columns (N): ");
                //n = Convert.ToInt32(Console.ReadLine());
                int[,] arr = new int[,]{ { 1, 5, 48 }, { 7, 11, 3 } };
                //Console.Write("Enter elements in the first matrix :\n");
                
                /* Sorting Matrix in ascending order*/
    
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        int row1 = i % n;
                        int col1 = i / n;
    
                        int row2 = j % n;
                        int col2 = j / n;
    
                        if (arr[row1, col1] > arr[row2, col2])
                        {
                            int temp = arr[row1, col1];
                            arr[row1, col1] = arr[row2, col2];
                            arr[row2, col2] = temp;
                        }
    
                    }
                }
            }
        }
    }
