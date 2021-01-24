    using (SqlDataReader reader2 = command2.ExecuteReader())
    {
          if(reader2.Read()) // this is needed
          {
              string ingredientName = reader2.GetString(0);
              ingredientNameConstruct = ingredientName;
          }
    }  
