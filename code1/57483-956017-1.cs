    public class BasePage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            var c = Page.LoadControl("SpiffyControl.ascx") as SpiffyBase;
    
            Page.Controls.Add(c);
    
            c.DoIt();
        }
    }
