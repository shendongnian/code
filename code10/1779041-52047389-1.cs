    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        Rectangle rect = PadRects
            .Where(r => r.Contains(e.Location))
            .FirstOrDefault();
        if (!rect.IsEmpty) {
            _clickedRectangle = rect; // Save the rectangle in a field to make it available
                                      // to the context menu item handler.
            contextMenuStrip1.Show(pictureBox1, e.Location);
        }
    }
