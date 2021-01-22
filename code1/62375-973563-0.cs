    protected override void OnInit(EventArgs e)
    {
        for (int i = 0; i != 10; ++i)
        {
            TextBox tb = new TextBox();
            // Init textBox here
            Label lb = new Label();
            // Init Label here
            Literal lt = new Literal();
            lt.Text = "<br />";
            this.Form.Controls.Add(tb);
            this.Form.Controls.Add(lb);
            this.Form.Controls.Add(lt);
        }
    }
