    if (Request.QueryString["gchap"] != null)
    {
        if (Controller.IsNumeric(Request.QueryString["gchap"].ToString()))
        {
            gchap = Convert.ToInt32(Request.QueryString["gchap"]);
            FillGeneralList();
            SetChapterTitle();
        }
    }
