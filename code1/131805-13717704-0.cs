            var wb = Globals.ThisAddIn.Application.ActiveWorkbook;
            var wb_vsto = wb.GetVstoObject();
    
    
            foreach (Excel.Worksheet ws in wb.Worksheets)
            {
                var wsv = ws.GetVstoObject();
                foreach (Excel.ListObject l in ws.ListObjects)
                {
                    MessageBox.Show(l.Name);
                    //var lo = wsv.Controls.AddListObject(l);
                    Microsoft.Office.Tools.Excel.ListObject lo = 
                              Globals.Factory.GetVstoObject(l);
                    // I can now get at the datasource if neede
                    var ds = lo.DataSource;
                    // In my case the datasource was DataTable.
                    DataTable t = (DataTable)d;
                    if (t.Rows.Count > 0)
                    {
                        foreach (DataRow r in t.Rows)
                        {
                        // Access row data.
                        }
                    }
                    //Excel.Range range = lo.Range;
                    //range.Activate();
               }
            }
