    <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("http://{0}/Dispute/Detail/{1}", Request.Url.Host, Request.QueryString.Get("did")));
    }
    </script>
