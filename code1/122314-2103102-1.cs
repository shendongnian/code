    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {           
        try
        {
           MethodOne()
        }
        catch (Exception)
        {
            (sender as DispatcherTimer).Stop();
        }  
    }
