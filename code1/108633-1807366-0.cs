    protected void Page_Load(object sender, EventArgs e)
    {
        linkBtn.Click += new EventHandler(handler1);
        linkBtn.Click += new EventHandler(handler2);
    }
    protected void handler1(object sender, EventArgs e)
    {
        lbl.Text += "33";
    }
    protected void handler2(object sender, EventArgs e)
    {
        lbl.Text += "66";
    }
