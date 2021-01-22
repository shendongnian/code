    try
    {
                        
    }
    catch (Exception ex)
    {
        formPanel.Visible = false;
        errorPanel.Visible = true;
    
        // Log error
        LogError(ex);
    }
