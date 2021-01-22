    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        foreach (CommandBinding cb in this.CommandBindings)
        {
            RoutedCommand command = cb.Command as RoutedCommand;
            if (command != null)
            {
                foreach (InputGesture inputGesture in command.InputGestures)
                {
                    KeyGesture keyGesture = inputGesture as KeyGesture;
                    if (keyGesture != null 
                            && keyGesture.Key == e.Key 
                            && keyGesture.Modifiers == Keyboard.Modifiers)
                    {
                        command.Execute(0, this);
                        e.Handled = true;
                    }
                }
            }
        }
    }
