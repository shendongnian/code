    richTextBox1.Text = "Line 1\nLine 2\nLine 3\nLine 4\nLine 5";
    string[] searchLines = new[] {"Line 2", "Line 3"};
    using (Font fnt = new Font("Verdana", 8F, FontStyle.Italic, GraphicsUnit.Point))
    {
        foreach (string line in searchLines)
        {
            int my1stPosition = richTextBox1.Find(line);
            if (my1stPosition > 0)
            {
                richTextBox1.SelectionStart = my1stPosition;
                richTextBox1.SelectionLength = line.Length;
                richTextBox1.SelectionFont = fnt;
                richTextBox1.SelectionColor = Color.CadetBlue;
            }
        }
    }
