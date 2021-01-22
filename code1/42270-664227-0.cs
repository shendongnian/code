    for (Int32 r0 = 0; r0 < dataTable.Rows.Count; r0++)
    {
       for (Int32 r1 = r0 + 1; r1 < dataTable.Rows.Count; r1++)
       {
          Boolean rowsEqual = true;
          for (Int32 c = 0; c < dataTable.Columns.Count; c++)
          {
             if (!Object.Equals(dataTable.Rows[r0][c], dataTable.Rows[r1][c])
             {
                rowsEqual = false;
                break;
             }
          }
          
          if (rowsEqual)
          {
             Console.WriteLine(
                String.Format("Row {0} is a duplicate of row {1}.", r0, r1))
          }
       }
    }
