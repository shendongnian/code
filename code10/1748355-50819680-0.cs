        string message;
        try
        {
        
             // at the end of try block
             message = "Solution Downloaded in C:/dwnload/working);
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        finally
        {
            MessageBox.Show(message);
        }
