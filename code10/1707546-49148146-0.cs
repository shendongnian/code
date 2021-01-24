    [HttpGet]
    public object Add(string data = "")
    {
        try
        {
            string result = "0";
            if (!string.IsNullOrEmpty(data))
            {
                var host = System.Web.HttpContext.Current.Request.UserHostName;
                var ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return new { response = result };
        }
        catch (Exception ex)
        {
            throw ex;
        }
