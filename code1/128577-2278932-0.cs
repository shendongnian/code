    private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
      if (Keyboard.Modifiers != ModifierKeys.Shift)
      {
        if (e.Key > Key.A && e.Key < Key.Z)
        {
          textBox1.Text += e.Key.ToString().ToLower();
        }
      }
      else
      {
        if (e.Key > Key.A && e.Key < Key.Z)
        {
          textBox1.Text += e.Key.ToString();
        }
      }            
      e.Handled = true;
    }
