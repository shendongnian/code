    public void Closing(object sender, EventArgs e)
    {
        if (closingInProgress)
        {
            return;
        }
        
        try 
        {
             closingInProgress = true;
             <Code, which can trigger Closing again>
        } 
        finally 
        {
             closingInProgress = false;
        }
    }
