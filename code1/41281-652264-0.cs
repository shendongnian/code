    private void Form1_MouseLeave(object sender, EventArgs e)
    {
        Point clientPos = PointToClient(Cursor.Position);
        if (!ClientRectangle.Contains(clientPos))
        {
            this.Opacity = 0.25;
        }
    }
