      private object mMissingValue = System.Reflection.Missing.Value;
    
      private void CreateWorkbook(string fileName)
      {
         if (File.Exists(fileName))
         {
            // Create the new excel application reference
            mExcelApplication = new Application();
            // Open the file
            Workbook excel_workbook = mExcelApplication.Workbooks.Open(templatePath,
                  mMissingValue, mMissingValue, mMissingValue, mMissingValue, mMissingValue,
                  mMissingValue, mMissingValue, mMissingValue, mMissingValue, mMissingValue,
                  mMissingValue, mMissingValue, mMissingValue, mMissingValue);
            Worksheet sheet = (Worksheet)mExcelWorkbook.Worksheets[1];
        }
     }
