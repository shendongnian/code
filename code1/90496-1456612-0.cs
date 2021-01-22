    public string GetInnerException(Exception ex)
    {
         if (ex.InnerException != null)
         {
            return string.Format("{0} > {1} ", ex.InnerException.Message, GetInnerException(ex.InnerException));
         }
       return string.Empty;
    }
