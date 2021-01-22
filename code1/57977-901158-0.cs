    private void Button_Click(object sender, EventArgs e)
    {
        try
        {
            ThrowingMethod();
        }
        catch
        { 
        }
    }
    
    private void ThrowingMethod()
    {
        try
        {
            throw new InvalidOperationException("some exception");
        }
        catch
        {
            throw;
        }
        finally
        {
            MessageBox.Show("finally");
        }
    }
