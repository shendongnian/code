    protected class BasePage : System.Web.UI.Page
    {
         protected override void InitializeCulture(object sender, EventArgs e)
         {
              this.Culture = Resources.Culture = Thread.CurrentThread.CurrentUICulture;
              
              base.InitializeCulture();
         }
    }
