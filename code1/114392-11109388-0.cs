        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string originalText = ((TextBox)sender).Text.Trim();
            if (originalText.Length>0)
            {
                int inputOffset = e.Changes.ElementAt(0).Offset;
                char inputChar = originalText.ElementAt(inputOffset);
                if (!char.IsDigit(inputChar))
                {
                    ((TextBox)sender).Text = originalText.Remove(inputOffset, 1);
                }
            }
        }
