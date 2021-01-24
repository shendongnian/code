    /// <summary>
        /// Gets the current Excel process and specified workbook and closes it.
        /// If the workbook was the only one in the application, it then closes excel as well.
        /// </summary>
        public static void CloseWorkbook()
        {
            try
            {
                Application excelApplicationProcess = (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application"); // get current excel process
    
                foreach (object wb in excelApplicationProcess.Workbooks)
                {
                    if (((Workbook)wb).FullName.Equals(Settings.Default.Test))
                        ((Workbook)wb).Close(false, Settings.Default.Test, Missing.Value);
                }
    
                if (excelApplicationProcess.Workbooks.Count == 0) // if it was the only one close excel as well
                    excelApplicationProcess.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
