        static void Main(string[] args)
        {
            Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlsApp == null)
            {
                //Any message
            }
            Workbook wb = xlsApp.Workbooks.Open("C:\\Users\\310231566\\Downloads\\main.xlsx",
                0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true);
            Sheets sheets = wb.Worksheets;
            Worksheet ws = (Worksheet)sheets.get_Item(1);
            Range firstColumn = ws.UsedRange.Columns[1];
            System.Array myvalues = (System.Array)firstColumn.Cells.Value;
            string[] strArray = myvalues.OfType<object>().Select(o => o.ToString()).ToArray();
            int j = 0;
            int avg = 0;
            int[] intArray = new int[strArray.Length-1];
            for (int i = 1; i < strArray.Length; i++)
            {
                intArray[j] = int.Parse(strArray[i]);
                avg  = avg + intArray[j];
                j++;
            }
            
            avg = avg/intArray.Length;
        }
