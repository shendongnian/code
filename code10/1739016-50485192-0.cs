    for(int col = 0; col < table.GetLength(0); col++)
        {
            int sum = 0;
            //ROW
            for (int row = 0; row < table.GetLength(1); row++)
            {
                if (table[col,row] != null)
                {
                    sum++;
                }
            }
            Debug.Log("table column: " + col + " has " + sum + " data");
        }
