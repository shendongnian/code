        if (this.Master.Page.Header != null && Session["RELOAD"] == null)
        {
            System.Web.UI.HtmlControls.HtmlHead hh = this.Master.Page.Header;
            System.Web.UI.HtmlControls.HtmlMeta hm = new System.Web.UI.HtmlControls.HtmlMeta();
            hm.Attributes.Add("http-equiv", "Refresh");
            hm.Attributes.Add("content", "3");
            hh.Controls.Add(hm);
        }
