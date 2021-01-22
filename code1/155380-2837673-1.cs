    /* inside Page_PreRender() handler...*/
    if (user_options.filterBadWords == true)
    {
        FilterControls(this);
    }    
    /* this does the real work*/
    void FilterControls(Control ctrl)
    {
        foreach (WebControl c in ctrl)
        {
            if (c.GetType() == "System.Web.UI.WebControls.TextBox")
            {
                TextBox1 txt = (TextBox) c;
                BadWordFilter.Instance.GetCleanString(TextBox1.Text);
            } 
        }
        if (ctrl.HasControls())
            FilterControls(ctrl); // recurse
    }
