    public static void DeleteCopies(DataTable allRows, DataTable rowsToDelete)
        {
            foreach (DataRow rowToDelete in rowsToDelete.Rows)
            {
                foreach (DataRow row in allRows.Rows)
                {
                    var rowToDeleteArray = rowToDelete.ItemArray;
                    var rowArray = row.ItemArray;
                    bool equalRows = true;
                    for (int i = 0; i < rowArray.Length; i++)
                    {
                        if (!rowArray[i].Equals(rowToDeleteArray[i]))
                        {
                            equalRows = false;
                            break;
                        }                            
                    }
                    if (equalRows)
                    {
                        allRows.Rows.Remove(row);
                        break;
                    }
                }
            }
        }
