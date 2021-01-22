            void Merge(DataTable masterDataTable, DataTable[] dataTables, int columnIndex)
            {
                foreach (DataTable dt in dataTables)
                {
                    DataColumn newColumn = masterDataTable.Columns.Add(dt.TableName, typeof(int));
                    int newColumnIndex = masterDataTable.Columns.IndexOf(newColumn);
                    for (int i = 0; i < dt.Rows.Count; i++)
			        {
                        masterDataTable.Rows[i][newColumnIndex] = dt.Rows[i][columnIndex];
                    }
                }
            }
