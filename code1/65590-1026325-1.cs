            //using Excel = Microsoft.Office.Interop.Excel;
            String[,] myArr = new string[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    myArr[x, y] = "Test " + y.ToString() + x.ToString();
                }
            }
            Excel.Application xlApp = new Excel.Application();
            xlApp.Visible = true;
            Excel.Workbook wb = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);
            Excel.Range rng = ws.Cells.get_Resize(myArr.GetLength(0), myArr.GetLength(1));
            rng.Value2 = myArr;
