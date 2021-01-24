    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        Rectangle? rect = PadRects
            .Where(r => r.Contains(e.Location))
            .FirstOrDefault();
        if (rect.HasValue) {
            _clickedRectangle = rect.Value; // Save the rectangle in a field to make it available
                                            // to context menu item handler.
            pictureBox1.ContextMenu.Show(pictureBox1, e.Location);
        }
    }
