    [DllImport("coredll.dll")]
    static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
    const int SW_MINIMIZED = 6;
    
    public static void MinimizeForm(IntPtr pFormHandle)
    {
    	ShowWindow(pFormHandle,SW_MINIMIZED);
    }
    
    private bool m_IsFormVisible = false;
    
    void m_MainForm_Deactivate(object sender, EventArgs e)
    {
    	m_IsFormVisible = false;
    }
    
    void m_MainForm_Activated(object sender, EventArgs e)
    {
    	m_IsFormVisible = true;
    }
    
    void m_MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
    	if (m_IsFormVisible)//very important !
    	{
    		e.Cancel = true;
    
    		//do something if you want
    
    		//minimize the form yourself
    		MinimizeForm(s_Instance.m_MainForm.Handle);
    	}
    }
