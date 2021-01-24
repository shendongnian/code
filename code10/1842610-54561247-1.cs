    protected void Button1_Click(object sender, EventArgs e)
    {
        int count = PlaceHolder1.Controls.Count;
        for (int i = 0; i < count; i++)
        {
            TextBox answer = PlaceHolder1.FindControl("answer " + i) as TextBox;
            Label1.Text += answer.Text + "<br>";
        }
    }
