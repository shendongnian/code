    public void AttachEvents()
    {
        _ctl.Click += new EventHandler( <>b_1 );
    }
    
    private void <>b_1( object sender, EventArgs e )
    {
        MessageBox.Show( "Hello!" );
    }
