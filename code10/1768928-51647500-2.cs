    //stream <= read your file into this stream parameter and pass to below variable
    public WorkbookPart GetWorkbook(Stream stream)
            {
                // Read the stream and convert it to a WorkbookPart object
                try
                {
                    m_ms = new MemoryStream();
    
                    stream.CopyTo(m_ms);
                    m_Doc = SpreadsheetDocument.Open(m_ms, false);
    
                    return m_Doc.WorkbookPart;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError(ex.Message + ex.StackTrace);
                }
    
                m_Doc = null;
                return null;
            }
