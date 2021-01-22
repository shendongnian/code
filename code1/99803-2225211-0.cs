    protected void btn1_Click(object sender, EventArgs e)
    {
        foreach (Control cont in tag1.Controls)
        {
            lbl1.Text += cont.ClientID + " ";
        }
        foreach (Control cont in tag2.Controls)
        {
            lbl2.Text += cont.ClientID + " ";
        }
    }
