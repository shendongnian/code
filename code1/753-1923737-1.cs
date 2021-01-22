            Regex NumEx = new Regex(@"^-?\d*\.?\d*$");
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox)
            {
                string text = (sender as TextBox).Text + e.Text;
                e.Handled = !NumEx.IsMatch(text);
            }
            else
                throw new NotImplementedException("TextBox_PreviewTextInput Can only Handle TextBoxes");
        }
