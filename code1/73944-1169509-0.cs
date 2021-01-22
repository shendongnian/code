    //Declare a flag to block the processing of your event
    private bool isEventBlocked = false;
    
    private void OnTextChanged(object sender, EventArgs e)
    {
        if(!isEventBlocked)
        {
            //do your stuff
        }
    }
    
    private void OnNewFile() //OR OnOpenFile()
    {
        try
        {
            isEventBlocked = true;
            CreateFile();
        }
        catch
        {
            //manage exception
        }
        finally
        {
            isEventBlocked = false;
        }
    }
