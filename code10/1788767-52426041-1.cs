    protected void lb1_Click(object sender, EventArgs e)
    {
        List<testtt> list = new List<testtt>();
        list.Add(new testtt() { Website = "www.gmail.com" });
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }
    protected void lb2_Click(object sender, EventArgs e)
    {
        List<testtt> list = new List<testtt>();
        list.Add(new testtt() { Website = "www.facebook.com" });
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }
    protected void lb3_Click(object sender, EventArgs e)
    {
        List<testtt> list = new List<testtt>();
        list.Add(new testtt() { Website = "www.google.com" });
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }
