    void GenerateWorkbook(...)
    {
      try
      {
        GenerateWorkbookInternal(...);
      }
      finally
      {
        GC.Collect();
        GC.WaitForPendingFinalizers();
      }
    }
    
    private void GenerateWorkbookInternal(...)
    {
      ApplicationClass xl;
      Workbook xlWB;
      try
      {
        xl = ...
        xlWB = xl.Workbooks.Add(...);
        ...
      }
      finally
      {
        ...
        Marshal.ReleaseComObject(xlWB)
        ...
      }
    }
