    public void finalize()
        {
            Microsoft.Office.Interop.Excel.Workbook myWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            var ranges = myWorkbook.Names;
            int leftoveritems;
            leftoveritems = ranges.Count;
            while (leftoveritems > 0)
            {
                int i = 1;
                try
                {
                    while (i <= leftoveritems)
                    {
                        myWorkbook.Names.Item(i).Delete();
                        //System.Windows.Forms.MessageBox.Show(i + " deleted.");
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(i + " failed " + ex.Message);
                }
                ranges = myWorkbook.Names;
                leftoveritems = ranges.Count;
            }
        }
