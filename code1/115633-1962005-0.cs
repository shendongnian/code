    using System;
    using System.Web.UI;
    
    public class BasePage : Page
    {
       public BasePage()
       {
            this.PreInit += new EventHandler(BasePage_PreInit);
       }
    
        void BasePage_PreInit(object sender, EventArgs e)
        {
            MasterPageFile = "~/Master1.master";
        }
    }
