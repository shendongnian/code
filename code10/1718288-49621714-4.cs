    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        DoRedirect("timeout.aspx");
    }
    
    public void DoRedirect(string page)
    {
        int TimeOut = (this.Session.Timeout * 60000);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendLine("<script type='text/javascript'>");
        sb.AppendLine("window.setInterval('Redirect()'," +TimeOut.ToString() + @"); ");
        sb.AppendLine(" function Redirect(){ ");
        sb.AppendLine("window.location.href='/" + page + @"';");
        sb.AppendLine("}");
        sb.AppendLine(" </script>");
    
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", sb.ToString());
    }
