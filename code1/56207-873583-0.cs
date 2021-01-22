    TextBox tb = new TextBox { Text = "Test", Multiline = true };
    Size size = System.Windows.Forms.TextRenderer.MeasureText(tb.Text, tb.Font);
    Point location = new Point( //Is this what you were looking for?
        tb.Location.X + size.Width, 
        tb.Location.Y + size.Height);
