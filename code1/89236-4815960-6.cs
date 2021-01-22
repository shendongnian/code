    <%@ Control Language="C#"%>
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.TrySkipIisCustomErrors = true;  //Suppress IIS7 custom errors
            Response.StatusCode = 404;
            SetRobotsHeaderMetadata();
        }
        private void SetRobotsHeaderMetadata()
        {
            HtmlMeta meta = new HtmlMeta();
            meta.Name = "robots";
            meta.Content = "noindex,follow";
            this.Page.Master.FindControl("cphPageMetaData").Controls.Add(meta);
        }
    </script>
