    public void SurroundWithTryCatch(Action action)
    {
        try
        {
            action();
        }
        catch(Exception ex)
        {
            //something even more boring stuff
        }    
    }
