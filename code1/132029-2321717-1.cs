    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Web;
    using System.Web.UI;
    
    public partial class FormattedTitle : System.Web.UI.UserControl
    {
        public string Title
        {
            get
            {  
                return this.lblTitle.Text;
            }
            set
            {
                this.lblTitle.Text = value;
            }
        }
    
        public string TitleFormat
        {
            get
            {  
                if(ViewState["TitleFormat"] != null)
                    return ViewState["TitleFormat"].ToString();
    
                return string.Empty;
            }
            set
            {
                ViewState["TitleFormat"] = value;
            }
        }
     
    
        public void Page_PreRender(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.TitleFormat))
            {
                this.lblTitle.Text = string.Format(this.lblTitle.Text, this.TitleFormat);
            }
        }
    }
