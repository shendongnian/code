    void btn1_Click(object sender, EventArgs e)
    {
        //remove right line
        text1.Text = text1.Lines[text1.Controls.IndexOf((Control)sender)].Remove(0);
        //remove button
        text1.Controls.Remove(text1.Controls.OfType<Button>().Last());
    }
