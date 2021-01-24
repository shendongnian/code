    bool successful = MyMethod(out string errorMessage)
    if (!successful)
    {
        MessageBox.Show(errorMessage);
    }
    public bool MyMethod(out string errorMessage)
    {
        errorMessage = "";
        try
        {
            // do some stuff
            return true;
        }
        catch(Exception ex)
        {
            errorMessage = ex.Message;
            return false;
        }
    }
