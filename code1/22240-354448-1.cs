    private void panel1_MouseLeave(object sender, EventArgs e)
    {
        Rectangle screenBounds = new Rectangle(this.PointToScreen(panel1.Location), panel1.Size);
        if (!screenBounds.Contains(MousePosition))
        {
            panel1.BackColor = Color.Gray;
        }
    }
