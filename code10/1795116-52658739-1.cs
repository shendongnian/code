    public void EventAdder() {
        Child.KeyDown += new KeyEventHandler( OnKeyDown );
    }
    private void OnKeyDown( object sender, KeyEventArgs e )
    {
        switch( e.KeyCode )
        {
            case Keys.Escape:
                Btn_Cancel_Click( sender, e );
                break;
            case Keys.Enter:
                Btn_Commit_Click( sender, e );
                break;
        }
    }
