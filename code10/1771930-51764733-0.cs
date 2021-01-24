            public static void WriteDataToFile(DataTable submittedDataTable, string submittedFilePath)
            {
                string[] columnNames = { "Column A", "Column B", "Column C", "Column D" };
                int[] columnIndexes = submittedDataTable.Columns.Cast<DataColumn>().Where(x => columnNames.Contains(x.ColumnName)).Select(x => x.Ordinal).ToArray();
                int i = 0;
                StreamWriter sw = null;
                sw = new StreamWriter(submittedFilePath, false);
                sw.WriteLine(string.Join(";", columnNames));
                foreach (DataRow row in submittedDataTable.Rows)
                {
                    object[] array = row.ItemArray;
                    string[] values = columnIndexes.Select(x => array[x].ToString()).ToArray();
                    string csv = string.Join(";", values);
                    sw.WriteLine(csv);
                }
                sw.Close();
            }
