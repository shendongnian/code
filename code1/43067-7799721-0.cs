        private void RemoveUselessFields(ref DataTable dtResults)
        {
            for (int i = dtResults.Columns.Count - 1; i >= 0; i--)
            {
                DataColumn column = dtResults.Columns[i];
                if (column.ColumnName.Substring(column.ColumnName.Length - 2, 2).ToUpper() == "ID") 
                {
                    dtResults.Columns.Remove(column);
                }
            }
            dtResults.AcceptChanges();
        }
