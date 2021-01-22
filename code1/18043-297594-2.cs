    private void PaintPanelOrButton(object sender, PaintEventArgs e)
    {
        // center the line endpoints on each button
        Point pt1 = new Point(button1.Left + (button1.Width / 2),
                button1.Top + (button1.Height / 2));
        Point pt2 = new Point(button2.Left + (button2.Width / 2),
                button2.Top + (button2.Height / 2));
    
        if (sender is Button)
        {
            // offset line so it's drawn over the button where
            // the line on the panel is drawn
            Button btn = (Button)sender;
            pt1.X -= btn.Left;
            pt1.Y -= btn.Top;
            pt2.X -= btn.Left;
            pt2.Y -= btn.Top;
        }
    
        e.Graphics.DrawLine(new Pen(Color.Red, 4.0F), pt1, pt2);
    }
