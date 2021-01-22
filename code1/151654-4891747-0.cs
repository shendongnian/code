    m_app = new Microsoft.Office.Interop.Excel.Application() { Visible = false };
    m_app.WorkbookBeforeClose += new AppEvents_WorkbookBeforeCloseEventHandler(m_app_WorkbookBeforeClose);
    m_workbook = m_app.Workbooks.Open(); // removing all arguements here for simplicity
    
    // event handler code
    void m_app_WorkbookBeforeClose(Workbook Wb, ref bool Cancel)
    {
      // making sure it is the same file that I opened
      if (Wb.FullName == m_workbook.FullName)
      {
        m_workbook = null;
      }
    }
    
    // when your app is closing
    public void Close()
    {
      if (m_workbook != null)
      {
        m_workbook.Close(Type.Missing, Type.Missing, Type.Missing);
      }
      m_app.Quit();         
    }
