    //private System.Windows.Forms.DataGridView dgvResults;
    dgvResults.DataSource = DB.getReport();
            
    Microsoft.Office.Interop.Excel.Application oXL;
    Microsoft.Office.Interop.Excel._Workbook oWB;
    Microsoft.Office.Interop.Excel._Worksheet oSheet;
    try
    {
        //Start Excel and get Application object.
        oXL = new Microsoft.Office.Interop.Excel.Application();
        oXL.Visible = true;
        oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
        oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;
        var dgArray = new object[dgvResults.RowCount, dgvResults.ColumnCount+1];
        foreach (DataGridViewRow i in dgvResults.Rows)
        {
            if (i.IsNewRow) continue;
            foreach (DataGridViewCell j in i.Cells)
            {
                dgArray[j.RowIndex, j.ColumnIndex] = j.Value.ToString();
            }
        }
        Microsoft.Office.Interop.Excel.Range chartRange;
        int rowCount = dgArray.GetLength(0);
        int columnCount = dgArray.GetLength(1);
        chartRange = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[2, 1]; //I have header info on row 1, so start row 2
        chartRange = chartRange.get_Resize(rowCount, columnCount);
        chartRange.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, dgArray);
        oXL.Visible = false;
        oXL.UserControl = false;
        string outputFile = "Output_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
        oWB.SaveAs("c:\\temp\\"+outputFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        oWB.Close();
    }
    catch (Exception ex)
    {
        //...
    }
