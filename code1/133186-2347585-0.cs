        private void CheckForContent()
        {
            Worksheet activeSheet = ActiveSheet;
            var range = activeSheet.get_Range("A1", GetExcelColumnName(activeSheet.Columns.Count)+activeSheet.Rows.Count.ToString() );
            range.Select();
            range.Copy();
            string text = Clipboard.GetText().Trim();
            if(string.IsNullOrEmpty(text))
            {
                MessageBox.Show("No text");
            }
        }
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;
            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }
