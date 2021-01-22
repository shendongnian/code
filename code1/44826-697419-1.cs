    if(!IsPostBack)
    {
        try
        {
            intMyId = (int)Request.QueryString["id"];
            //Do something with intMyId
        }
        catch(InvalidCastException ex)
        {
           //Record and show error message
        }
    }
