            public DataTable MergeTables(DataTable Table1, DataTable Table2)
        {
            DataTable Mergetable = new DataTable();
            foreach (DataColumn d in Table1.Columns)
            {
                Mergetable.Columns.Add(d.ColumnName);
            }
            foreach (DataColumn d in Table2.Columns)
            {
                Mergetable.Columns.Add(d.ColumnName);
            }
            int Table1Cols = Table1.Columns.Count;
            int Table1Rows = Table1.Rows.Count;
            int Table2Cols = Table2.Columns.Count;
            int Table2Rows = Table2.Rows.Count;
            DataRow row2;
            bool end = false;
            int RowCount = 0;
            while (!end)
            {
                end = true;
                if (RowCount < Table1Rows || RowCount < Table2Rows)
                {
                    end = false;
                    row2 = Mergetable.NewRow();
                    if (RowCount < Table1Rows)
                    {
                        for (int col = 0; col < Table1Cols; col++)
                        {
                            row2[col] = Table1.Rows[RowCount][col];
                        }
                    }
                    if (RowCount < Table2Rows)
                    {
                        for (int col = 0; col < Table2Cols; col++)
                        {
                            row2[col + Table1Cols] = Table2.Rows[RowCount][col];
                        }
                    }
                    Mergetable.Rows.Add(row2);
                }
                RowCount++;
            }
            return Mergetable;
        }
