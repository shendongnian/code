    string[,] multidimensionalArray = new string[dt.Rows.Count, dt.Columns.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    multidimensionalArray[i, j] = dt.Rows[i][j].ToString(); 
                }
            }
