    protected void YourButton_Click(object sender, EventArgs e)
    {
       if (this.InnerButtonClick != null)
       {
          this.InnerButtonClick(sender, e);
       }
    }
