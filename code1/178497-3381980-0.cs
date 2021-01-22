    private void abuttonispressed(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.S)) 
        {
            //click event is raised here
            button1.Focus();
            button1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, button1));
        } 
    }
