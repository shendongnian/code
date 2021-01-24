    public void Button_Click(object sender, ExecutedRoutedEventArgs e)
    {
       if (textBox.isFocused)
       {
          e.handled = true;
       }
    }
