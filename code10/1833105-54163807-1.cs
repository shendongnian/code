     List<Category> categories = new List<Category>();
     //I will use this variable to hold the category id of the row that the datareader is reading
      int categoryId= 0;  
      Category category = null;
    
        while (dr.Read())
            {    
                 //if the current category id is different than the variable categoryId I will instantiante a new Category,
                // otherwise I will add the a new subcategory to the existing category object
                if(categoryId != dr.GetInt32(dr.GetOrdinal("id")))
                    { 
                        category = new Category();
                        category.CategoryName =   dr.GetString(dr.GetOrdinal("category_name"));
                     
                        category.Subcategory.Add(new Subcategory { SubcategoryName = dr.GetString(dr.GetOrdinal("subcategory_name")) });
    
                    }
                    else
                    {
                        category.Subcategory.Add(new Subcategory { SubcategoryName = dr.GetString(dr.GetOrdinal("subcategory_name")) });
    
                    }
    
                    if (CategoryId != dr.GetInt32(dr.GetOrdinal("id")) && category !=null)
                    {
                        categorias.Add(category);
                    }
    
                  CategoryId =  dr.GetInt32(dr.GetOrdinal("id"));
                }
    
    
                conn.Close();
    
                return categories;
