    _updating = true;
    _textBox.Text = "New Text";  
    ...      
    _textBox_TextChanged( object sender, EventArgs e )
    {
        if( _updating ) { _updating = false; return; }
        // Do something special with the new text.
    }
