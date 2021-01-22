    using (new SqlConnection ...)
    {
      c.Open();
      blabla;
    }
    
    using (new SqlConnection ... )
    {
      c.Open();
      no kaboom?
    }
