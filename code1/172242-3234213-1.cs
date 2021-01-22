    private void AjaxPostbackButton_Click(object sender, EventArgs e)
    {
        MyLabel.Text = "Ajax Postback: " + DateTime.Now;
    }
    private void FullPostbackButton_Click(object sender, EventArgs e)
    {
        MyLabel.Text = "Full Postback: " + DateTime.Now;
    }
