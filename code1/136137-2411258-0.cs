    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    using System.Text;
    
    namespace Sandbox
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                StringBuilder html = new StringBuilder(@"<TABLE BORDER='1' WIDTH='100%'>");
                if (!IsPostBack)
                {
                    html.Append(@"<TR><TD>SomeStuff</TD></TR>");
                }
                else
                {
                    html.Append(@"<TR><TD>Some New Stuff</TD></TR>");
                }
                html.Append(@"</TABLE>");
                this.PreAcquisitionDiv.InnerHtml = html.ToString();
            }
    
            protected void btnTest_OnClick(object sender, EventArgs e)
            {
            }
        }
    }
