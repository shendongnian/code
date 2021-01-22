    using System;
    using System.Web.UI;
    
    namespace GetPCName {
       public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {            
            pcname.InnerHtml = Environment.MachineName;
        }
       }
    }
