    protected void Page_Load(object sender, EventArgs e)
    {
      byte[] pdfdata = GetMyPdfDataSomehow();
    
      Response.Clear();
      Response.ContentType = "application/pdf";
      Response.BinaryWrite(pdfdata);
      if (NoCaching)
      {
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
      }
      else
      {
        Response.Cache.SetExpires(DateTime.Now.AddDays(7));
        Response.Cache.SetCacheability(HttpCacheability.Public);
        Response.Cache.SetValidUntilExpires(true);
      }
      Response.End();
    }
