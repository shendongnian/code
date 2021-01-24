    /// <summary>
    /// Get a reference to an already running or a newly started Outlook instance
    /// </summary>
    Microsoft.Office.Interop.Outlook.Application GetOutlookApp()
    {
        Microsoft.Office.Interop.Outlook.Application app = null;
    
        // Try to get running instance
        try
        {
            app = Marshal.GetActiveObject("Outlook.Application") as Microsoft.Office.Interop.Outlook.Application;
        }
        catch(Exception)
        {
            // Ignore exception when Outlook is not running
        }
    
        // When outlook was not running, try to start it
        if(app == null)
        {
            app = new Microsoft.Office.Interop.Outlook.Application();
        }
    
        return app;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        const string fileName = @"D:\MyDings.pst";
    
        var app = GetOutlookApp();
        var nameSpace = app.GetNamespace("MAPI");
    
        nameSpace.AddStore(fileName);
    
        MessageBox.Show("Done");
    }
