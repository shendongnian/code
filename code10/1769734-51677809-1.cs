    bool found = false;
    for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == Convert.ToString(idChosen))
                    {
                        //note that this will print your id
                        Console.WriteLine(matrix[i, j]);
                        //this would print where it found it
                        Console.WriteLine("Found at [" + i + "," + j + "]");
                        found = true;
                    }
                }
            }
    
    if (!found)
    {
        Console.WriteLine("The chosen ID does not exist");
    }
                    
