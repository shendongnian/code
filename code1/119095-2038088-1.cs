        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V) 
            {
                richTextBox1.Text += (string)Clipboard.GetData("Text"); 
                e.Handled = true; 
            }
        }
