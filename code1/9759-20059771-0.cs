            try
            {
                FunctionThatCallsExcel(sourcePath, targetPath);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
