    private void MyControl_MouseLeave(object sender, EventArgs e)
    {
        if (this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
        {
            // the mouse is inside the control bounds
        }
        else
        {
            // the mouse is outside the control bounds
        }
    }
