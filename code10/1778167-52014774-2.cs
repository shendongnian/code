    using System;
    namespace MainClass
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i, j, m, n, sum = 0; int count = 0; Console.Write("The MxN matrix\n"); Console.Write("Enter the number of rows and columns of the matrix :\n"); Console.Write("Rows (M): "); m = Convert.ToInt32(Console.ReadLine()); Console.Write("Columns (N): "); n = Convert.ToInt32(Console.ReadLine()); int[,] arr = new int[m, n]; Console.Write("Enter elements in the first matrix :\n");
    
                /* Entering matrix elements */
    
                for (j = 0; j < n; j++)
                {
                    for (i = 0; i < m; i++)
                    {
                        Console.Write("element - [{0}],[{1}] : ", i, j);
                        arr[i, j] = Convert.ToInt32(Console.ReadLine());
    
                        /* Calculating odd numbers of the matrix */
    
                        if (arr[i, j] % 2 != 0)
                        {
                            sum += arr[i, j];
                        }
                    }
                }
                Console.Write("\nThe matrix is:\n");
                for (j = 0; j < n; j++)
                {
                    for (i = 0; i < m; i++)
                        Console.Write("{0} ", arr[i, j]);
                    Console.Write("\n");
                }
                Console.Write("\nThe sum of odd numbers is: {0}", sum);
    
                /* Sorting Matrix in ascending order*/
    
                for (i = 0; i < arr.Length - 1; i++)
                {
                    for (j = i + 1; j < arr.Length; j++)
                    {
                        int row1 = i % m;
                        int col1 = i / m;
    
                        int row2 = j % m;
                        int col2 = j / m;
    
                        if (arr[row1, col1] > arr[row2, col2])
                        {
                            int temp = arr[row1, col1];
                            arr[row1, col1] = arr[row2, col2];
                            arr[row2, col2] = temp;
                        }
    
                    }
                }
    
                
                Console.Write("\nAscending order: ");
                for (j = 0; j < n; j++)
                {
                    for (i = 0; i < m; i++)
                        Console.Write("{0} ", arr[i, j]);
                }
                Console.Read();
            }
        }
    }
