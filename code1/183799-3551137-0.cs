    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class UserControls_Messages_MessageFolder_MessageFolder : System.Web.UI.UserControl, IMessageFolder
    {
        private static int IDCOLUMNINDEX = 0;
        private static int DELETECOLUMNINDEX = 1;
        private static int FROMCOLUMNINDEX = 2;
        private static int TOCOLUMNINDEX = 3;
    
        public event SelectedIndexChangedEventHandler SelectedIndexChanged;
        public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);
    
        public event ComposeMessageEventHandler ComposeMessage;
        public delegate void ComposeMessageEventHandler(object sender, Common.MessageComposeEventArgs e);
    
        VAC.Data.VACDB db = new VAC.Data.VACDB();
    
        public int? MessageID
        {
            get
            {
                int id;
                if (int.TryParse(hfMessageID.Value, out id))
                    return id;
                else
                    return null;
            }
        }
    
        public CustomDataViews.MessageQuery.MailType MailType { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MailType == CustomDataViews.MessageQuery.MailType.SentMail)
            {
                butCompose.Visible = false;
            }
            Refresh();
        }
    
        public void Refresh()
        {
            gvMessages.DataSource = new CustomDataViews.MessageQuery().GetMessages(MailType, cbShowDeleted.Checked);
            gvMessages.DataBind();
            Common.HideColumn(gvMessages, IDCOLUMNINDEX);
            if (MailType == CustomDataViews.MessageQuery.MailType.ReceivedMail)
                Common.HideColumn(gvMessages, TOCOLUMNINDEX);
            else
                Common.HideColumn(gvMessages, FROMCOLUMNINDEX);
        }
    
        protected void gvMessages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Common.GridView_RowDataBound(sender, e);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CustomDataViews.MessageQuery.Message dataItem = ((CustomDataViews.MessageQuery.Message)e.Row.DataItem);
    
                if (dataItem.IsDeletedSender && MailType == CustomDataViews.MessageQuery.MailType.SentMail
                    || dataItem.IsDeletedRecipient && MailType == CustomDataViews.MessageQuery.MailType.ReceivedMail)
                {
                    foreach (TableCell tc in e.Row.Cells)
                        tc.Enabled = false;
                    e.Row.Cells[DELETECOLUMNINDEX].Enabled = true;
                    ((LinkButton)e.Row.Cells[DELETECOLUMNINDEX].Controls[0]).Text = "Undelete";
                    ((LinkButton)e.Row.Cells[DELETECOLUMNINDEX].Controls[0]).Attributes.Clear();
                }
                if (!dataItem.IsRead && MailType == CustomDataViews.MessageQuery.MailType.ReceivedMail)
                {
                    //colouring for initial load
                    if ((e.Row.RowState & DataControlRowState.Alternate) == DataControlRowState.Alternate)
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml(Common.BGColourGreenAlternate);
                    else
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml(Common.BGColourGreen);
                    //colouring for onmouse out
                    Common.ApplyStylingToRow(e.Row, Common.SelectedBGColour(sender), Common.BGColourGreen, Common.BGColourGreenAlternate);
                }
            }
    
            if (ScriptManager.GetCurrent(this.Page).IsInAsyncPostBack && e.Row.RowType == DataControlRowType.DataRow)
                Common.GridViewAddRowClick(gvMessages, e.Row, false);
        }
    
        protected void gvMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfMessageID.Value = gvMessages.SelectedValue != null ? gvMessages.SelectedValue.ToString() : "";
            if (MailType == CustomDataViews.MessageQuery.MailType.ReceivedMail)
            {
                var mess = (from m in db.Messages where m.MessageID == MessageID.Value select m);
                if (mess.Count() == 1)
                {
                    var message = mess.First();
                    message.IsRead = true;
                    message.Save();
                }
            }
    
            if (this.SelectedIndexChanged != null)
                SelectedIndexChanged(this, new EventArgs());
            this.Refresh();
        }
    
        protected void gvMessages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id;
            if (int.TryParse(((GridView)sender).Rows[e.RowIndex].Cells[IDCOLUMNINDEX].Text, out id))
            {
                var message = (from m in db.Messages where m.MessageID == id select m).First();
                if (!message.IsDeletedRecipient && MailType == CustomDataViews.MessageQuery.MailType.ReceivedMail)
                    message.IsDeletedRecipient = true;
                else
                    message.IsDeletedRecipient = false;
                message.Save();
    
                if (!message.IsDeletedSender && MailType == CustomDataViews.MessageQuery.MailType.SentMail)
                    message.IsDeletedSender = true;
                else
                    message.IsDeletedSender = false;
                message.Save();
    
                gvMessages.SelectedIndex = -1;
                gvMessages_SelectedIndexChanged(gvMessages, new EventArgs());
            }
            Refresh();
        }
    
        protected override void Render(HtmlTextWriter writer)
        {
            Common.GridViewRowClick_Render(gvMessages);
            base.Render(writer);
        }
    
        protected void butCompose_Click(object sender, EventArgs e)
        {
            if (this.ComposeMessage != null)
            {
                this.ComposeMessage(this, new Common.MessageComposeEventArgs());
            }
        }
    
        protected void cbShowDeleted_CheckChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
