            for(int i=0;i<noOfRows;i++)
            {
                for(int j=0;j<noOfCols;j++)
                {
                    Console.Write(array2D[i,j]);
                    if(j<noOfCols-1)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine();
            }
