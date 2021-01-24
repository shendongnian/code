    List<ProductFromSql> Filtered = new List<ProductFromSql>();
    
    productFromSqls.ForEach(x => productFromApis.ForEach(ele => 
                                 {
                                    if(!AreObjectsEqual(x, ele)) 
                                        Filtered.Add(x);  
                                 }));
    
    
    public bool AreObjectsEqual(ProductFromSql obj1, ProductFromApi obj2)
    {
       return (obj1.id == obj2.idEshop && obj1.active == obj2.active)//......) //Add other properties of your class which are common in both in ........
    }
