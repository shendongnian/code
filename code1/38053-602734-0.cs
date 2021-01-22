    private string FillDataTable(out DataTable results)
    {
    
      try
    {
      results = new DataTable(); //something like this;
      return String.Empty;
    }
    catch (Exception ex)
    {
      results = null;
     return ex.Message;
    
    }
}
