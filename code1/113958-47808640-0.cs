    private void Log(string s , Color? c = null)
            {
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.SelectionLength = 0;
                richTextBox.SelectionColor = c ?? Color.Black;
                richTextBox.AppendText((richTextBox.Lines.Count() == 0 ? "" : Environment.NewLine) + DateTime.Now + "\t" + s);
                richTextBox.SelectionColor = Color.Black;
                
            }
