    protected void btnReply_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
        rplycmnt =(item.FindControl("textCommentReplyParent") as TextBox).Text.Trim();
        answerid=Convert.ToInt32((item.FindControl("lblAnsId") as Label).Text);
        OnlineSubjects onlinesub = new OnlineSubjects()
        {
            reply = rplycmnt,
            AnsId = answerid
        };
        onlinesub.addReply();
        GetAnswer(); 
    }
