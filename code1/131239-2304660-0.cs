    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        TextBox txtBox = new TextBox();
        txtBox.Location = new Point(e.X, e.Y);
        this.Controls.Add(txtBox);
        txtBox.Focus();
    }
