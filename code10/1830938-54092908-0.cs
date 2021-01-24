    if (string.IsNullOrEmpty(telnr.Text))
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "corectyesno()", true);  return;
    }
    else
    {
        try
        {
            // your SQL code...
        }
        // etc.
    }
