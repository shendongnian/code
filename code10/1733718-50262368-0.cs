    public void btnOpenExcel_Click(object sender, EventArgs e)
        {
            // Upload data from .xls file
            try
            {
                // Pulls up file reader
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "xlsx|*.xlsx", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        lblFileName.Text = ofd.FileName;
                        // use selected file name to populate Spreadsheet Viewer
                        var myData = SpreadsheetDocument.Open(ofd.FileName, false).GetDataTableFromSpreadSheet();
                        dataGridView.DataSource = myData;
                    }
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    static class Extensions
    {
        // this extension is for populating the GridView with values from a spreadsheet. 
        public static DataTable GetDataTableFromSpreadSheet(this SpreadsheetDocument document, int columns = -1, bool excludeHeader = true)
        {
            var results = new DataTable();
            try
            {
                var sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                var id = sheets.First().Id.Value;
                var part = (WorksheetPart)document.WorkbookPart.GetPartById(id);
                var sheet = part.Worksheet;
                var data = sheet.GetFirstChild<SheetData>();
                var rows = data.Descendants<Row>();
                if (rows.Count() != 0)
                {
                    var colCount = rows.First().Cast<Cell>().Count();
                    if (columns > colCount || columns <= 0)
                        columns = colCount;
                    foreach (var cell in rows.First().Cast<Cell>().Take(columns))
                        results.Columns.Add(cell.GetValue(document));
                    foreach (var row in rows.Skip(Convert.ToInt32(excludeHeader)))
                        results.Rows.Add((from cell in row.Cast<Cell>().Take(columns) select cell.GetValue(document)).ToArray());
                }
            }
            catch (Exception)
            {
                results = new DataTable();
            }
            return results;
        }
        public static string GetValue(this Cell cell, SpreadsheetDocument document)
        {
            string result = string.Empty;
            try
            {
                if (cell != null && cell.ChildElements.Count != 0)
                {
                    var part = document.WorkbookPart.SharedStringTablePart;
                    if (cell.DataType != null && cell.DataType == CellValues.SharedString)
                        result = part.SharedStringTable.ChildElements[Int32.Parse(cell.CellValue.InnerText)].InnerText;
                    else
                        result = cell.CellValue.InnerText;
                }
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;
        }
    }
