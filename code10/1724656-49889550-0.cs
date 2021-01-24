            System.Data.DataTable tbl = new System.Data.DataTable();
            // Add Dummy Columns
            for (int i = 0; i <= 11; i++)
            {
                tbl.Columns.Add(i.ToString());
            }
            // Assume We Have Data
            // Split Table Into Lists of Tables
            List <System.Data.DataTable> tables = new List<System.Data.DataTable>();
            for ( int i = 0; i <= 2; i++)
            {
                int firstColumn = i * 4;
                int lastColumn = i * 4 + 3;
                System.Data.DataTable tblCopy = tbl.Copy();
                for ( int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (j < firstColumn || j > lastColumn)
                        tblCopy.Columns.Remove(tbl.Columns[j].ColumnName);
                }
                tables.Add(tblCopy);
            }
