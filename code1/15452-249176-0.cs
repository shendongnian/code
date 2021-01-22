    using (SqlCommand cmd = new SqlCommand(...))
    {
      try
      {
        /* call stored procedure */
      }
      catch (SqlException ex)
      {
        /* handles the exception. does not rethrow the exception */
      }
    }
