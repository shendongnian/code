    private void OpenReadExcel()
    {
        var dlg = new OpenFileDialog();
        if (dlg.ShowDialog() != DialogResult.OK) return;
        var exApp = new Microsoft.Office.Interop.Excel.Application();
        Workbook exWbk = exApp.Workbooks.Open(dlg.FileName);
        Worksheet wSh = exWbk.Sheets[1];
        int k = 2;
        Customers.Clear();
        while (wSh.Cells[k, 1].Text != "" && wSh.Cells[k, 1].Value != null)
        {
            var rowExcelModel = new ExcelModel()
            {
                CustomerNr = wSh.Cells[k, 1].Text,
                Address = wSh.Cells[k, 2].Text,
                Product = wSh.Cells[k, 3].Text,
                Quantity = wSh.Cells[k, 4].Text
            };
            Customers.Add(rowExcelModel);
            k++;
        }
        exApp.Quit();        
    }
