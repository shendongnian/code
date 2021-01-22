    protected bool ValidateProfile()
    {
        bool returnValue = true;
        
        if(String.IsNullOrEmpty(txtFName))
        {
             returnValue=false;
        } 
        else if(String.IsNullOrEmpty(txtLName))
        {
             returnValue = false;
        } 
        else if(String.IsNullOrEmpty(txtEMail))
        {
             returnValue = false;
        }
        
        return returnValue;
        
    }
