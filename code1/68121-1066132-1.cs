    protected string WindowStatusText = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Refresh this page 60 seconds before session timeout, effectively resetting the session timeout counter.
                MetaRefresh.Attributes["content"] = Convert.ToString((Session.Timeout * 60) - 60) + ";url=KeepAlive.aspx?q=" + DateTime.Now.Ticks;
                WindowStatusText = "Last refresh " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            }
        }
