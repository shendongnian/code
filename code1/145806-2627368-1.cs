    this.openFileDialog1.FileName = "*.xls";
      if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
       {
          Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
             openFileDialog1.FileName, 0, true, 5,
              "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
              0, true); 
         Excel.Sheets sheets = theWorkbook.Worksheets;
         Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
         for (int i = 1; i <= 10; i++)
         {
         Excel.Range range = worksheet.get_Range("A"+i.ToString(), "J" + i.ToString());
         System.Array myvalues = (System.Array)range.Cells.Value;
         string[] strArray = ConvertToStringArray(myvalues);
         }
    }
    string[] ConvertToStringArray(System.Array values)
    { 
    
    // create a new string array
    string[] theArray = new string[values.Length];
    
    // loop through the 2-D System.Array and populate the 1-D String Array
     for (int i = 1; i <= values.Length; i++)
      {
       if (values.GetValue(1, i) == null)
        theArray[i-1] = "";
      else
       theArray[i-1] = (string)values.GetValue(1, i).ToString();
      }
    
      return theArray;
    }
