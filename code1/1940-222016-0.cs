    using System;
    
    using System.Data;
    
    using System.Configuration;
    
    using System.Web;
    
    using System.Web.Security;
    
    using System.Web.UI;
    
    using System.Web.UI.HtmlControls;
    
    using System.Web.UI.WebControls;
    
    using System.Web.UI.WebControls.WebParts;
    
    using BlogEngine.Core;
    
    using BlogEngine.Core.Web.Controls;
    
    using System.Collections.Generic;
    
    
    
    /// <summary>
    
    /// Summary description for PostSecurity
    
    /// </summary>
    
    [Extension("Checks to see if a user can see this blog post.",
    
                "1.0", "<a href=\"http://www.lavablast.com\">LavaBlast.com</a>")]
    
    public class RequireLogin
    {
    
        static protected ExtensionSettings settings = null;
    
    
    
        public RequireLogin()
        {
    
            Post.Serving += new EventHandler<ServingEventArgs>(Post_Serving);
    
    
    
            ExtensionSettings s = new ExtensionSettings("RequireLogin");
    
            // describe specific rules for entering parameters
    
            s.Help = "Checks to see if the user has any of those roles before displaying the post. ";
    
            s.Help += "You can associate a role with a specific category. ";
    
            s.Help += "All posts having this category will require that the user have the role. ";
    
            s.Help += "A parameter with only a role without a category will enable to filter all posts to this role. ";
    
            ExtensionManager.ImportSettings(s);
    
            settings = ExtensionManager.GetSettings("PostSecurity");
    
        }
    
    
    
        protected void Post_Serving(object sender, ServingEventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            if(HttpContext.Current.Request.RawUrl.Contains("syndication.axd"))
            {
                return;
            }
    
            if (user == null)
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
        }
    }
