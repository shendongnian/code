    private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
       if (e.Text.Equals("_"))
       {
          // process underscore...
       }
    }
      private void Window_TextInput(object sender, TextCompositionEventArgs e)
      {
         if (e.Text.Equals("_"))
         {
            // process underscore...
         }
      }
