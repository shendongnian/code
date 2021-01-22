    //tb variable is your RichTextBox
    //inputPreview variable is your PictureBox
    using (Graphics g = inputPreview.CreateGraphics())
    {
        Point loc = tb.PointToScreen(new Point(0, 0));
        g.CopyFromScreen(loc, loc, tb.Size);
        Point pt = tb.GetPositionFromCharIndex(tb.TextLength);
        g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(pt.X, 0, 100, tb.Height));
    }
    inputPreview.Invalidate();
    inputPreview.Show();
    //Your code here (example: tb.Select(...); tb.SelectionColor = ...;)
    inputPreview.Hide();
