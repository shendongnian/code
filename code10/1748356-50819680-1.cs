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
            // in general, keep the finally code as the minimum needed for sanity cleanup. 
        }
        // If you rethrow your exception, and still want to show the message box, then might have a reason for wanting this instruction back inside the finally block. 
        MessageBox.Show(message);
