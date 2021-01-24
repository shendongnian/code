      private void TextBox_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
            {
                if (Window.Current.CoreWindow.GetKeyState(VirtualKey.Shift).HasFlag(CoreVirtualKeyStates.Down)&& e.Key == Windows.System.VirtualKey.Enter)
                {
                   //Add New Line
                }
                else if (e.Key == Windows.System.VirtualKey.Enter)
                {
                    //This will prevent system from adding new line
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
