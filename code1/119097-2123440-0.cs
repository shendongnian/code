            private void rtb_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    ((RichTextBox)sender).Paste(DataFormats.GetFormat("Text"));
                        e.Handled = true;
                }
            }
