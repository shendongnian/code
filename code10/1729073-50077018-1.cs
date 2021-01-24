    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            FileUpload fu = item.FindControl("FileUpload1") as FileUpload;
            if (fu.HasFile)
            {
                //process file here
            }
        }
    }
