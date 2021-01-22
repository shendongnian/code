    void Page_Load()
    {
        ContentPlaceHolder cph;
        Literal lit;
        
        cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        
        if (cph != null) {
            lit = (Literal) cph.FindControl("Literal1");
            if (lit != null) {
                lit.Text = "Some <b>HTML</b>";
            }
        }
           
    }
