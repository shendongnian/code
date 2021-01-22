    private delegate void CallAsyncDelegate();
    private void button_Click( object sender, EventArgs e )
    {
        Thread thread = new Thread( GetDBValues );
        thread.IsBackground = true;
        thread.Start();
    }
    
    private void GetDBValues()
    {
        foreach( ... )
        {
            Invoke( new CallAsyncDelegate( UpdateUI ) );
        }
    }
    
    private void UpdateUI()
    {
        /* Update the user interface */
    }
