        static void CombineFiles(List<string> files, string outputPath)
        {
            //Create a workbook instance
            Workbook workbook = new Workbook();
            workbook.Version = ExcelVersion.Version2013;
            //Clear worksheets (by default there are 3 worksheets in a new created workbook)
            workbook.Worksheets.Clear();
            //Copy worksheets from Excel files into the new workbook
            foreach (string fileName in files)
            {
                Workbook tempWorkbook = new Workbook();
                tempWorkbook.LoadFromFile(fileName);
                foreach (Worksheet tempSheet in tempWorkbook.Worksheets)
                {
                    workbook.Worksheets.AddCopy(tempSheet);
                }
            }
            //Merge worksheets into a single worksheet
            Worksheet sheet1 = workbook.Worksheets[0];
            for (int i = 1; i < workbook.Worksheets.Count; i++)
            {
                Worksheet otherSheet = workbook.Worksheets[i];
                //use Copy(CellRange sourceRange, CellRange destRange, bool copyStyle) method
                otherSheet.Copy(otherSheet.Range[otherSheet.FirstRow, otherSheet.FirstColumn, otherSheet.LastRow, otherSheet.LastColumn], sheet1[sheet1.LastRow + 1, 1, sheet1.LastRow + otherSheet.LastRow, otherSheet.LastColumn], true);
                otherSheet.Remove();
            }
            //Save the file
            workbook.SaveToFile(outputPath, ExcelVersion.Version2013);
            System.Diagnostics.Process.Start(outputPath);
        }
 
