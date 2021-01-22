        private void CoordinateValidation(object sender, TextChangedEventArgs e) {
            TextBox inputBox = e.OriginalSource as TextBox;
            inputBox.TextChanged -= CoordinateValidation;
            int caretPos = inputBox.CaretIndex;
            foreach (TextChange change in e.Changes) {
                if (inputBox.Text.Substring(change.Offset, change.AddedLength).Any(c => !ValidChars.Contains(c)) ||
                    inputBox.Text.Count(c => c == '.') > 1 ||
                    (inputBox.Text.Length > 0 && inputBox.Text.Substring(1).Contains('-'))) {
                    inputBox.Text = inputBox.Text.Remove(change.Offset, change.AddedLength);
                    caretPos -= change.AddedLength;
                }
            }
            inputBox.CaretIndex = caretPos;
            inputBox.TextChanged += CoordinateValidation;
        }
