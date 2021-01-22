     private void txtScan_KeyDown(object sender, KeyRoutedEventArgs e)
            {
                if (e.Key == Windows.System.VirtualKey.Enter)
                {
                   //Do something here...
                  
                    txtScan.Text = "";
                    txtScan.Focus(FocusState.Programmatic);
                    e.Handled = true;  //keeps event from bubbling to next handler
                }
            }
