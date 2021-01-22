    if (user_options.filterBadWords == true)
    {
        foreach (WebControl c in Page.Controls)
        {
            if (c.GetType() == "System.Web.UI.WebControls.TextBox")
            {
                TextBox1 txt = (TextBox) c;
                BadWordFilter.Instance.GetCleanString(TextBox1.Text);
            } 
        }
    }    
