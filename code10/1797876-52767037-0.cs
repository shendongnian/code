    if (string.IsNullOrEmpty(e.Message) == false)
            {
        
                if (e.ID == 0)
                {
                    result = Array.ConvertAll(e.Message.Split(new[] { ',', }, StringSplitOptions.RemoveEmptyEntries), Double.Parse);
        
        
                    for (int x = 0; x < result.Length; x++)
                    {
        
                        resultarray2D[x / 3, x % 3] = result[x];
                    }
                    int rowLength = resultarray2D.GetLength(0);
                    int colLength = resultarray2D.GetLength(1);
        
                    for (int i = 0; i < rowLength; i++)
                    {
                        for (int j = 0; j < colLength; j++)
                        {
                            Trace.WriteLine(string.Format("{0} ", resultarray2D[i, j]));
                        }
                         Trace.WriteLine("\n");
                    }
        
                }
