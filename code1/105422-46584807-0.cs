    public void UpdateExcelApplication(SqlDataTable dataTable)
        {
            var objects = new string[dataTable.Rows.Count, dataTable.Columns.Count];
            var rowIndex = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                var colIndex = 0;
                foreach (DataColumn column in dataTable.Columns)
                {
                    objects[rowIndex, colIndex++] = Convert.ToString(row[column]);
                }
                rowIndex++;
            }
            var range = this.workSheet.Range[$"A3:FW{dataTable.Rows.Count + 2}"];
            range.Value = objects;
            this.workSheet.Columns.AutoFit();
            this.workSheet.Rows.AutoFit();
        }
