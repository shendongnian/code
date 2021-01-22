        public interface IJQueryPage
        {
        }
    
        public abstract class AdminPage : System.Web.UI.Page
        {
            protected override void OnInit(EventArgs e)
            {
                //if not an admin - get out
                if(!CurrentUserIsAdmin()) Response.End();
                base.OnInit (e);
            }
            protected override void OnLoad(EventArgs e)
            {
                if (this is IJQueryPage)
                {
                    RegisterJQueryScript();
                }            
                
                base.OnLoad (e);
            }
        }
    
        public class AdminJQueryPage : AdminPage, IJQueryPage
        { 
        }
