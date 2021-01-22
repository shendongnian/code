    public List<ProductsDAL> GetAllProducts(string sqlQuery) 
    { 
        return GetDataSet(sqlQuery, "tblProducts").
            Tables[0].Rows.Cast<System.Data.DataRow>().
            Select(p => new ProductsDAL()
            {
                Product_ID = p["Product_ID"].ToString(),
                ProductDescr = p["ProductDescr"].ToString()
            }).ToList();    
    } 
