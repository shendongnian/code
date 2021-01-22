    private void FunctionWrapper(string sourcePath, string targetPath)
    {
        try
        {
            FunctionThatCallsExcel(sourcePath, targetPath);
        }
        finally
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
