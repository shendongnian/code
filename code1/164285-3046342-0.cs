    public Control GetControlToInvokeAgainst()
    {
        if(Application.Forms.Count > 0)
        {
            return Application.Forms[0];
        }
        return null;
    }
        
