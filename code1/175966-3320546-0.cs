    ...
    SqlDataReader dr = sc.ExecuteReader();
    List<Category> LV = new List<Category>();          
    
    using(dr) {
      while (dr.Read()) {
    
        Category C = new Category();
    
        C.CategoryID = Convert.ToInt32(dr["CategoryID"]);
        C.Name = dr["Name"].ToString();
        C.DisplayOrder=Convert.ToInt32(dr["DisplayOrder"]);
    
        LV.Add(C);
    
      }
    }
    sc.Connection.Close();
    return LV;
