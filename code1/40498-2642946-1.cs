    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
    
        Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
    }
    
    private bool m_isExplicitClose = false;// Indicate if it is an explicit form close request from the user.
    
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    
    {
    
        base.OnClosing(e);
    
        if (m_isExplicitClose == false)//NOT a user close request? ... then hide
        {
            e.Cancel = true;
            this.Hide();
        }
    
    }
    
    private void OnTaskBarMenuItemExitClick(object sender, RoutedEventArgs e)
    
    {            
        m_isExplicitClose = true;//Set this to unclock the Minimize on close 
    
        this.Close();
    }
