    private void button1_Click( object sender, EventArgs e )
    {
    	Debug.WriteLine( "button1_Click" );
    	updating = true;
    	boolList[0] = true;
    	bs.ResetBindings( false );
    	Application.DoEvents();
    	updating = false;
    }
    
    private void checkBox1_CheckedChanged( object sender, EventArgs e )
    {
    	Debug.WriteLine( "checkBox1_CheckedChanged" );
    	if ( !updating )
    	{
    		Debug.WriteLine( "!updating" );
    		MessageBox.Show( "CheckChanged fired outside of updating" );
    	}
    }
