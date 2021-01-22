    public void RedirectPermanent(string newPath)
    {
      HttpContext.Current.Response.Clear();
      HttpContext.Current.Response.Status = "301 Moved Permanently";
      HttpContext.Current.Response.AddHeader("Location", newPath);
      HttpContext.Current.Response.End();
    }
