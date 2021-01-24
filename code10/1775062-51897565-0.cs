     class Program
    {
        static void Main(string[] args)
        {
            ExcelPackage p = new ExcelPackage();
            try
            {
                p = new ExcelPackage();
            }
            catch (System.IO.IOException fex)
            {
                //file is open
                Console.WriteLine("Can not process while file is open.Please close file and try again.");
                return;
            }
            catch (System.IO.InvalidDataException lex)
            {
                //invalid file type
                Console.WriteLine("Invalid File Type. Please Try Again.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled Exception. Please Contact Developer.");
                return;
            }
            var wb = p.Workbook;            
            //create table
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Col1"));
            dt.Columns.Add(new DataColumn("Col2"));
            dt.Columns.Add(new DataColumn("Col3"));
            dt.Columns.Add(new DataColumn("Col4"));
            dt.Columns.Add(new DataColumn("Col5"));
            //fill table
            DataRow workRow;
            for (int i = 0; i <= 9; i++)
            {
                workRow = dt.NewRow();
                workRow["Col1"] = string.Format("Row {0} Col 1", i);
                workRow["Col2"] = string.Format("Row {0} Col 2", i);
                workRow["Col3"] = string.Format("Row {0} Col 3", i);
                workRow["Col4"] = string.Format("Row {0} Col 4", i);
                workRow["Col5"] = string.Format("Row {0} Col 5", i);
                dt.Rows.Add(workRow);
            }
            //create worksheet
            var ws = wb.Worksheets.Add("Foo");
            //load data into cell A1            
            ws.Cells["A1"].LoadFromDataTable(dt, true);
            ws.Cells.AutoFitColumns();
            using (ExcelRange objRange = ws.Cells["A1:XFD1"])
            {
                objRange.Style.Font.Bold = true;
                objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                objRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#B7DEE8"));
            }
            p.SaveAs(new FileInfo(@"C:\FooFolder\Foo.xlsx"));
            Console.WriteLine("It's Successful");
        }              
    }
