    void GenerateWorkbook(...)
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
        GC.Collect();
        GC.WaitForPendingFinalizers();
      }
    }
