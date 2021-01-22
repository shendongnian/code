    public class ReadOnlyTextBox : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down)
            {
                base.OnKeyDown(e);
                return;
            }
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control ||
                (Keyboard.Modifiers & ModifierKeys.Apple) == ModifierKeys.Apple)
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
