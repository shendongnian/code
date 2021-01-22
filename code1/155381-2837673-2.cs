    /* inside Page_PreRender() handler...*/
    if (user_options.filterBadWords == true)
    {
        FilterControls(this);
    }    
    /* this does the real work*/
    private void FilterControls(Control ctrl)
    {
        foreach (Control c in ctrl.Controls)
        {
            if (c.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
            {
                TextBox t = (TextBox)c;
                /* do your thing */
                t.Text = BadWordsFilter(t.Text);
            }
            if (c.HasControls())
                FilterControls(c);
        }
    }
