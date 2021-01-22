        void updateoutput(string text)
        {
            try
            {
                richTextBox1.SuspendLayout();
                int len = text.Length;
                int start = richTextBox1.Text.Length;
                richTextBox1.Text += text + Environment.NewLine;
                richTextBox1.Select(start, len);
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.Select(richTextBox1.Text.Length, 0);
                richTextBox1.ScrollToCaret();
            }
            finally
            {
                richTextBox1.ResumeLayout();
            }
        }
