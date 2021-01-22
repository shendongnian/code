    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class UserControls_Messages_MessageBox_MessageBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mv1.MessageID = mf1.MessageID;
                mc1.Visible = false;
            }
        }
    
        protected void SelectedMessageChanged(object sender, EventArgs e)
        {
            mv1.MessageID = ((IMessageFolder)sender).MessageID;
            mc1.Visible = false;
        }
    
        protected void ComposeMessage(object sender, Common.MessageComposeEventArgs e)
        {
            mc1.Visible = true;
            mc1.DataBind();
            if (e.SendToUserID.HasValue)
                mc1.SendToUserID = e.SendToUserID;
            if (!string.IsNullOrEmpty(e.Subject))
                mc1.SendToSubject = e.Subject;
        }
    
        protected void mc1_MessageSent(object sender, EventArgs e)
        {
            mf2.Refresh();
        }
    }
