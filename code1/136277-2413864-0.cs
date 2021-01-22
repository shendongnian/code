    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if ((e.Key == Key.P) &amp;&amp; ((e.Modifiers &amp; ModifierKeys.Alt) == ModifierKeys.Alt))
        {
            MessageBox.Show("Thanks!");
            e.Handled = true;
        }
    }
