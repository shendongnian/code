    public partial class _Default : System.Web.UI.Page
    {
        private const int _refresh_In_Seconds = 10;
        public override void OnInit(object sender, EventArgs e)
        {
            HtmlMeta meta = new HtmlMeta();
            meta.Name = "refresh";
            meta.Content = _refresh_In_Seconds + "; url=Default.aspx"; 
    
            this.Header.Controls.Add(meta);
        }
    }
