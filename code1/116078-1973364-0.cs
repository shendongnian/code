    Microsoft.Office.Interop.Excel.Application xl = 
        new Microsoft.Office.Interop.Excel.Application();
     
    xla.Visible = true;
    Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
    Worksheet ws = (Worksheet)xla.ActiveSheet;
    int i = 1;
    int j = 1;
    foreach (ListViewItem comp&nbsp;in lvwResults.Items)
    {
        ws.Cells[i, j] = comp.Text.ToString();
        //MessageBox.Show(comp.Text.ToString());
        foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
        {
            ws.Cells[i, j] = drv.Text.ToString();
            j++;
        }
        j = ;1;
        i++;
    }
