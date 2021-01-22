    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Buffer = false;
        Response.Clear();
        Response.Write("<html><body>");
        Response.Write("1\n");
        Response.Flush();
        Thread.Sleep(2000);
        Response.Write("1\n");
        Response.Flush();
        Thread.Sleep(2000);
        Response.Write("1\n");
        Response.Flush();
        Thread.Sleep(2000);
        Response.Write("1\n");
        Response.Flush();
        Response.Write("</body></html>");
        Response.End();
    }
