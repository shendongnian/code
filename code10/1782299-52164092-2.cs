    static void importRecordMethod(string[,] matrix)
        {
            string file = "../archives/Export.txt";
            if (!File.Exists(file))
                return;
            try
            {
                using (var sr = new StreamReader(file))
                {
                    for (var i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (var j = 0; j < matrix.GetLength(1); j++)
                        {
                            string line;
                            if ((line = sr.ReadLine()) != null)
                            {
                                matrix[i, j] = line;
                            }
                        }
                    }
                    // check if matrix is empty
                    for (var i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (var j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.WriteLine(matrix[i, j]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
