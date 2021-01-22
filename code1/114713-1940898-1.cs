    protected override void OnInit(EventArgs e) {
        System.Web.UI.WebControls.PlaceHolder cnt = (System.Web.UI.WebControls.PlaceHolder)this.FindControl("MyPlaceHolder1");
        Agile.Portal.Framework.BaseModule mod = (Agile.Portal.Framework.BaseModule)LoadControl("~/modules/HTMLModule/HtmlModule.ascx");
        cnt.Controls.Add(mod);
        base.OnInit(e);
    }
