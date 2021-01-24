    public static void DeleteCopies(DataTable allRows, DataTable rowsToDelete)
    {
        foreach (DataRow rowToDelete in rowsToDelete.Rows)
        {
            foreach (DataRow row in allRows.Rows)
            {
                bool equalRows = true;
                if (!Enumerable.SequenceEqual(rowToDelete.ItemArray, row.ItemArray))
                {
                    equalRows = false;
                }
                if (equalRows)
                {
                    allRows.Rows.Remove(row);
                    break;
                }
            }
        }
    }
