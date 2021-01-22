    private void MovieItem_Click(object sender, EventArgs e)
    {
        foreach (Control y in this.Parent.Controls)
        {
            if (y is MovieItem && y != this)
                y.BackColor = Color.White;
        }
        this.BackColor = Color.LightBlue;
    }
