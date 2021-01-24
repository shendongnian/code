        private void richTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                e.IsInputKey = true;
                BeginInvoke(new Action(() => {
                    MessageBox.Show("Handled with RichTextBox");
                }));
            }
        }
