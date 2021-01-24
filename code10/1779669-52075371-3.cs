    public WorkbookPart ImportExcel()
        {
            try
            {
                string path = @"your path to excel document";
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    MemoryStream m_ms = new MemoryStream();
                    fs.CopyTo(m_ms);
                    SpreadsheetDocument m_Doc = SpreadsheetDocument.Open(m_ms, false);
                    return m_Doc.WorkbookPart;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.Message + ex.StackTrace);
            }
            return null;
        }
