    public void AttachParam(ref DbCommand command, Dictionary<string, string> parameters)
    {
      try
      {
         if (parameters.Count > 0)
         {
            foreach (KeyValuePair<string, string> kvp in parameters)
            {
               command.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
         }
      }
      catch (Exception ex)
      {
         throw;
      }
    }
