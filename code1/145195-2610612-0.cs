    private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs args)
    {
        if(args.RowIndex == 0)
        {
            Font font = new Font("Verdana", 11);
            Brush brush = new SolidBrush(Color.FromArgb(70, Color.DarkGreen));
            StringFormat format = new StringFormat
            {
                FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip,
                Trimming = StringTrimming.None,
            };
            //Setup the string to be printed
            string printMe = String.Join(" ", Enumerable.Repeat("RUNNING", 10).ToArray());
            printMe = String.Join(Environment.NewLine, Enumerable.Repeat(printMe, 50).ToArray());
            //Draw string onto a bitmap
            Bitmap buffer = new Bitmap(args.RowBounds.Width, args.RowBounds.Height);
            Graphics g = Graphics.FromImage(buffer);
            Point absolutePosition = dataGridView1.PointToScreen(args.RowBounds.Location);
            g.CopyFromScreen(absolutePosition, Point.Empty, args.RowBounds.Size);
            g.RotateTransform(-45, MatrixOrder.Append);
            g.TranslateTransform(-50, 0, MatrixOrder.Append); //So we don't see the corner of the rotated rectangle
            g.DrawString(printMe, font, brush, args.RowBounds, format);
            //Draw the bitmap onto the table
            args.Graphics.DrawImageUnscaledAndClipped(buffer, args.RowBounds);
        }
    }
