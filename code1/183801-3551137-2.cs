    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    using VAC.Data;
    
    public partial class UserControls_Messages_MessageCompose_MessageCompose : System.Web.UI.UserControl
    {
        public event MessageSentEventHandler MessageSent;
        public delegate void MessageSentEventHandler(object sender, EventArgs e);
    
        public int? SendToUserID
        {
            set
            {
                if (ddlToUser.Items.FindByValue(value.HasValue ? value.Value.ToString() : "") != null)
                    ddlToUser.SelectedValue = value.HasValue ? value.Value.ToString() : "";
                else
                    Common.RegisterStartupScript(this, "alert('Error :  You are unauthorized to respond to this message.');");
            }
        }
    
        public string SendToSubject
        {
            set
            {
                tbSubject.Text = "RE: " + value;
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessageSentText.Visible = false;
        }
    
        private static string SENTMESSAGETEXT = "Your message was sent at {0} to {1}.";
    
        protected void butSend_Click(object sender, EventArgs e)
        {
            Message m = new Message();
            m.Body = tbBody.Text;
            m.FromUserID = Common.CurrentUserID;
            m.IsRead = false;
            m.SentDate = DateTime.Now;
            m.Subject = tbSubject.Text;
            int tid;
            if (int.TryParse(ddlToUser.SelectedValue, out tid))
                m.ToUserID = tid;
            m.Save();
            lblMessageSentText.Text = string.Format(SENTMESSAGETEXT, DateTime.Now.ToString(), ddlToUser.SelectedItem.Text);
            lblMessageSentText.Visible = true;
    
            ddlToUser.SelectedValue = null;
            tbSubject.Text = "";
            tbBody.Text = "";
    
            if (this.MessageSent != null)
                MessageSent(this, new EventArgs());
        }
    }
