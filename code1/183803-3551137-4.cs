    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class UserControls_Messages_MessageView_MessageView : System.Web.UI.UserControl
    {
        public event ComposeMessageEventHandler ComposeMessage;
        public delegate void ComposeMessageEventHandler(object sender, Common.MessageComposeEventArgs e);
    
        public int? MessageID
        {
            get
            {
                int mid;
                return int.TryParse(hfMessageID.Value, out mid) ? mid : new int?();
            }
            set
            {
                hfMessageID.Value = (value.HasValue) ? value.ToString() : "";
                BindMessageView();
            }
        }
    
        private void BindMessageView()
        {
            if (MessageID.HasValue)
            {
                CustomDataViews.MessageQuery.Message message = new CustomDataViews.MessageQuery().GetMessage(MessageID.Value);
    
                this.Visible = true;
                lblBody.Text = message.Body;
                lblFromUser.Text = message.FromUser;
                lblSentDate.Text = message.SentDate.ToString();
                lblSubject.Text = message.Subject;
                lblToUser.Text = message.ToUser;
            }
            else
            {
                this.Visible = false;
                lblBody.Text = "";
                lblFromUser.Text = "";
                lblSentDate.Text = "";
                lblSubject.Text = "";
                lblToUser.Text = "";
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void lbReply_Click(object sender, EventArgs e)
        {
            var mess = (from m in new VAC.Data.VACDB().Messages where m.MessageID == MessageID select m);
            if (mess.Count() == 1)
            {
                if (this.ComposeMessage != null)
                    this.ComposeMessage(this, new Common.MessageComposeEventArgs(mess.First().FromUserID, mess.First().Subject));
            }
        }
    }
