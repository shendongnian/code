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
                                Console.WriteLine($"Loop index {j + matrix.GetLength(0) * i}, Line: {line}");
                                matrix[i, j] = line;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
