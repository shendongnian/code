    using System;
    
    namespace GridViewEventHandling
    {
        public partial class SampleData : System.Web.UI.UserControl
        {
            public event EventHandler OnLinkClick;
    
            protected void HandleClick(object sender, EventArgs args)
            {
                if (OnLinkClick != null)
                    OnLinkClick(sender, args);
            }
        }
    }
