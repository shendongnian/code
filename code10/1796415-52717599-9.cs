    private void lbl_MouseClick(object sender, MouseEventArgs e)
    {
        Label lbl = sender as Label;
        //...
        MessageBox.Show(lbl.Name + " : Ouch! You clicked on " + lbl.Text.Trim());
    }
