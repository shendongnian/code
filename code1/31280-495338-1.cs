    using System;
    using System.Web.UI;
    public class BasePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Master && Master is BaseMaster)
            {
                ((BaseMaster)Master).MyString = "Some value";
            }
        }
    }
