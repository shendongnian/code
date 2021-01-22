    public bool SomeFunction()
    {
        bool success = true;
        try
        {
            //somecode
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.message);
            success = false;
        }
    
        return success;
    }
