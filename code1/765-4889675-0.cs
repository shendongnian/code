    protected override void OnPreviewTextInput( System.Windows.Input.TextCompositionEventArgs e )
    {
    	try
    	{
    		Convert.ToDecimal( this.Text.Insert( this.CaretIndex, e.Text ) );
    	}
    	catch { e.Handled = true; }
    
    	base.OnPreviewTextInput( e );	
    }
