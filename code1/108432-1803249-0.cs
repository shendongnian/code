    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (dragging)
        {
            if (e.Button == MouseButtons.Left)
            {
                int horizontalChange = (e.X - startingX) * -1;  // move the image inverse to direction dragged
                int verticalChange = (e.Y - startingY);
                pictureBox1.Left += horizontalChange;
                pictureBox1.Top += verticalChange;
            }
        }
        startingX = e.X;
        startingY = e.Y;
    }
