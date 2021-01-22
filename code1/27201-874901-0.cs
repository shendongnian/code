    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Inner : System.Web.UI.UserControl
    {
        public string Url
        {
            get
            {
                return this.linkHref.HRef;
            }
            set
            {
                this.linkHref.HRef = value;
            }
        }
    }
