    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        Repeater1.DataSource = Enumerable.Range(1, 10);
        Repeater1.DataBind();
      }
    }
    protected void ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
      Response.Write("The no. " + ((LinkButton)e.CommandSource).Text + " button was clicked!");
    }
