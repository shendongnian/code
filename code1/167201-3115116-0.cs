    protected void Page_Init(object sender, EventArgs e)
    {
        for (int i = 0; i < 20; i++)
        {
            this.Form.Controls.Add(new TextBox() { Visible = false });
        }
    }
    protected void addTextboxButton_Click(object sender, EventArgs e)
    {
        TextBox tb = this.Form.Controls.OfType<TextBox>().FirstOrDefault(box => box.Visible == false);
        if (tb != null) tb.Visible = true;
    }
