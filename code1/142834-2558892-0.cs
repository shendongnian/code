    Control c= GetPostBackControl(this.Page);
    if(c != null)
    {
       if (c.Id == "btnSearch")
       {
           SetFocus(txtSearch);
       }
    }
