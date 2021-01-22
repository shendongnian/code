    public class ReadOnlyTextBox : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control || 
                (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Apple)
            {
                if (e.Key == Key.A || e.Key == Key.C)
                {
                    // allow select all and copy!
                    base.OnKeyDown(e);
                    return;
                }
            }
            e.Handled = true;
            base.OnKeyDown(e);
        }
    }
