    using System;
    using System.Threading;
    
    namespace ShiftMatrix
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                MatrixOperation objMatrixOperation = new MatrixOperation();
    
                //Create a matrix
                int[,] mat = new int[,]
            {
            {1, 2},
            {3,4 },
            {5, 6},
            {7,8},
            {8,9},
            };
    
                int type = 2;
                int counter = 0;
                if (type == 1)
                {
                    counter = mat.GetLength(0);
                }
                else
                {
                    counter = mat.GetLength(1);
                }
                while (true)
                {
                    for (int i = 0; i < counter; i++)
                    {
                        ShowMatrix(objMatrixOperation.ShiftMatrix(mat, i, type));
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                    }
                }
            }
            public static void ShowMatrix(int[,] matrix)
            {
                int rows = matrix.GetLength(0);
                int columns = matrix.GetLength(1);
                for (int k = 0; k < rows; k++)
                {
                    for (int l = 0; l < columns; l++)
                    {
                        Console.Write(matrix[k, l] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        class MatrixOperation
        {
            public int[,] ShiftMatrix(int[,] origanalMatrix, int shift, int type)
            {
                int rows = origanalMatrix.GetLength(0);
                int cols = origanalMatrix.GetLength(1);
    
                int[,] _tmpMatrix = new int[rows, cols];
                if (type == 2)
                {
                    for (int x1 = 0; x1 < rows; x1++)
                    {
                        int y2 = 0;
                        for (int y1 = shift; y2 < cols - shift; y1++, y2++)
                        {
                            _tmpMatrix[x1, y2] = origanalMatrix[x1, y1];
                        }
                        y2--;
                        for (int y1 = 0; y1 < shift; y1++, y2++)
                        {
                            _tmpMatrix[x1, y2] = origanalMatrix[x1, y1];
                        }
                    }
                }
                else
                {
                    int x2 = 0;
                    for (int x1 = shift; x2 < rows - shift; x1++, x2++)
                    {
                        for (int y1 = 0; y1 < cols; y1++)
                        {
                            _tmpMatrix[x2, y1] = origanalMatrix[x1, y1];
                        }
                    }
                    x2--;
                    for (int x1 = 0; x1 < shift; x1++, x2++)
                    {
                        for (int y1 = 0; y1 < cols; y1++)
                        {
                            _tmpMatrix[x2, y1] = origanalMatrix[x1, y1];
                        }
                    }
    
                }
                return _tmpMatrix;
            }
        }
    
    }
