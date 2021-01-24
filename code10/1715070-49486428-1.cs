    public void imgValidAdd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            // Some Code
            if(A==b)
            {
                // Open Confirm dialog
                Page.ClientScript.RegisterStartupScript(typeof(Page), "openconfirmjs", "<script>openconfirmdialog();</script>");
            }
        }
        catch()
        {
        }
    }
