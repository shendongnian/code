    public bool SomeFunction()
    {
        try
        {
            //somecode
            return true;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.message);
        }
        return false;
    }
