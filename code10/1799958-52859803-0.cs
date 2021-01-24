    private void comboBox1_Enter(object sender, EventArgs e)
    {
        ComboBox combo = sender as ComboBox;
        if (!combo.DroppedDown)
        {
            if (combo.PointToClient(Cursor.Position).X < 
                combo.ClientRectangle.Width - SystemInformation.VerticalScrollBarWidth)
            {
                combo.DroppedDown = true;
                Cursor = Cursors.Arrow;
            }
        }
    }
