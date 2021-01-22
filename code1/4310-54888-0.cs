    public void btnSubmitClick(object sender, EventArgs e)
    {
        if (this.txtMultiLine.Text.StartsWith("\r\n"))
        {
            this.txtMultiLine.Text = "\r\n" + this.txtMultiLine.Text;
        }
    }
