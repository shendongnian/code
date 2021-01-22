    foreach (Control control in Page.Controls[0].FindControl("ContentPlaceHolder1").Controls)
    {
        if (control is TextBox)
        {
            ((TextBox)control).Focus();
            break;
        }
    }
