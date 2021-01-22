    int timeout = 20;
    for (i=0; i < timeout; i++)
    {
        bool blocked = Convert.ToBoolean(ie.Eval("Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();"));
        if (blocked)
        {
           System.Threading.Thread.Sleep(200);
        }
        else
        {
            break;
        }
     }
    
