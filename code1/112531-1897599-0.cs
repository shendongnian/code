    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string[] content = txtContent.Text.Split('\n');
        
        string ret = "";
        foreach (string s in content)
        {
            string[] parts = s.Split('=');
            if (parts.Count() == 2)
            {
                ret = ret + string.Format("{0} = {1}\n", parts[1].Trim(), parts[0].Trim());
            }
        }
        lblContentTransformed.Text = "<pre>" + ret + "</pre>";
    
    }
