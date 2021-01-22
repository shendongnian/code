    protected void deleteButton_Click(object sender, EventArgs e)
        {
            LinkButton theSender = (LinkButton)sender;
            int imageId = System.Convert.ToInt32(theSender.CommandArgument.ToString());
        }
