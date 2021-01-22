      private bool _clearNext = false;
      private void Window_KeyUp(object sender, KeyEventArgs e)
      {
         if ( _clearNext )
         {
            _clearNext = false;
            e.Handled = true;
         }
         else if (e.Key == Key.OemMinus)
         {
            e.Handled = true;
         }
         else if (e.Key == Key.OemQuestion)
         {
            e.Handled = true;
         }
      }
      private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
      {
         if (e.Text.Equals("_"))
         {
            KeyEventArgs args = new KeyEventArgs(Keyboard.PrimaryDevice,
               Keyboard.PrimaryDevice.ActiveSource, 0, Key.OemMinus);
            args.RoutedEvent = Keyboard.KeyUpEvent;
            InputManager.Current.ProcessInput(args);
            e.Handled = true;
            _clearNext = true;
         }
         else if (e.Text.Equals("?"))
         {
            KeyEventArgs args = new KeyEventArgs(Keyboard.PrimaryDevice,
               Keyboard.PrimaryDevice.ActiveSource, 0, Key.OemQuestion);
            args.RoutedEvent = Keyboard.KeyUpEvent;
            InputManager.Current.ProcessInput(args);
            e.Handled = true;
            _clearNext = true;
         }
      }
