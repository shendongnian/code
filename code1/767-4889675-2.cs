    protected override void OnPreviewTextInput( System.Windows.Input.TextCompositionEventArgs e )
    {
    	try
    	{
    		if ( String.IsNullOrEmpty( SelectedText ) )
    		{
    			Convert.ToDecimal( this.Text.Insert( this.CaretIndex, e.Text ) );
    		}
    		else
    		{
    			Convert.ToDecimal( this.Text.Remove( this.SelectionStart, this.SelectionLength ).Insert( this.SelectionStart, e.Text ) );
    		}
    	}
    	catch
    	{
    		// mark as handled if cannot convert string to decimal
    		e.Handled = true;
    	}
    
    	base.OnPreviewTextInput( e );
    }
