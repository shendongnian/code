    SqlConnection c = null; 
      try { 
        c = new SqlConnection(@"..."); 
        c.Open(); 
      ... 
      } finally { 
        if (c != null) //<== check for null 
          c.Dispose(); 
      } 
