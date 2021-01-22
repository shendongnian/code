    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        e.Handled = ProcessKeyDown(e.KeyCode);
    }
    
    // event handler for the PreViewKeyDown event for the buttons
    private void ArrowButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        ProcessKeyDown(e.KeyCode);
        
    }
    
    private bool ProcessKeyDown(Keys keyCode)
    {
        switch (keyCode)
        {
            case Keys.Up:
                {
                    // act on up arrow
                    return true;
                }
            case Keys.Down:
                {
                    // act on down arrow
                    return true;
                }
            case Keys.Left:
                {
                    // act on left arrow
                    return true;
                }
            case Keys.Right:
                {
                    // act on right arrow
                    return true;
                }
        }
        return false;
    }
