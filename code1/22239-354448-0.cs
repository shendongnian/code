    private void panel1_MouseLeave(object sender, EventArgs e)
    {
        if (panel1.GetChildAtPoint(panel1.PointToClient(MousePosition)) == null)
        {
            panel1.BackColor = Color.Gray;
        }
    }
