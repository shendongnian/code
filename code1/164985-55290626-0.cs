        public bool IsDirty {
            set {
                if(value) {
                    txtValue.Background = Brushes.LightBlue;
                } else {
                    txtValue.Background = IsReadOnly ? Brushes.White : Brushes.LightYellow;
                }
            }
            get {
                return txtValue.Background == Brushes.LightBlue;
            }
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e) {
            TextBox tb = ((TextBox)sender);
            string originalText = tb.Text;
            string newVal = "";
            //handle negative
            if (e.Text=="-") {
                if(originalText.IndexOf("-") > -1 || tb.CaretIndex != 0 || originalText == "" || originalText == "0") {
                    //already has a negative or the caret is not at the front where the - should go
                    //then ignore the entry
                    e.Handled = true;
                    return;
                }
                        
                //put it at the front
                newVal = e.Text + originalText;
            } else {
                //normal typed number
                newVal = originalText + e.Text;
            }
            
            //check if it's a valid double if so then dirty
            double dVal;
            e.Handled = !double.TryParse(newVal, out dVal);
            if(!e.Handled) {
                IsDirty = true;
            }
        }
        private void PreviewKeyUp(object sender, KeyEventArgs e) {
            //handle paste
            if ((Key.V == e.Key || Key.X == e.Key) && Keyboard.Modifiers ==  ModifierKeys.Control) {
                IsDirty = true;
            }
            //handle delete and backspace
            if (e.Key == Key.Delete || e.Key == Key.Back) {
                IsDirty = true;
            }
        }
        private void PreviewExecuted(object sender, ExecutedRoutedEventArgs e) {
            //handle context menu cut/paste
            if (e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) {
                IsDirty = true;
            }
        }
