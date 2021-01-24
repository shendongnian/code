        try
    {
       int total = manager.GetAllBooks().Tables[0].Rows.Count;
       lblmsg1.Text = total.ToString();
    
       FilesPercentage = total.ToString();
    
    }
    catch (Exception ex)
    {
       throw ex;
    }
