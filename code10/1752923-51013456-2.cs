    protected void Page_Load(object sender, EventArgs e)
    {
        // on first load, store the text message in hidden field
        if (!Page.IsPostBack)
        {
            hfMessage.Value = lblMessage.Text;
        }
        if (Page.IsPostBack)
        {
            // on postback, set the text message from hidden field which is populated in button click
            lblMessage.Text = hfMessage.Value;
        }
    }
    protected void btnFlash_Click(object sender, EventArgs e)
    {
        // This would be your message, I just used a date-time to create dynamic message.
        string newMessage = DateTime.Now.Second.ToString() + " Records Selected";
        // store the new message in hidden field to change the text on post-back, otherwise your message will be restored on post-back
        hfMessage.Value = newMessage;
        // call JS from code-behind, pass the control ID and the new message
        ScriptManager.RegisterStartupScript(this, GetType(), "flash", "startEffect('lblMessage', '" + newMessage + "');", true);
    }
