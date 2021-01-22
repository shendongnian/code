    // This is only replacing the foreach part, the rest of your code is still valid
    foreach (System.Web.UI.Control ctl in cell.Controls)
    {
        if (ctl.GetType().ToString().Contains("DataControlLinkButton"))
        {
            cell.Attributes.Add("title", cell.Text);
        }
    }
