public List<ProductsDAL> GetAllProducts(string sqlQuery)
  {
     DataSet dsinsert = GetDataSet(sqlQuery, "tblProducts");
     List<ProductsDAL> bPList = new List<ProductsDAL>();
     foreach (DataRow item in dsinsert.Tables[0].Rows)
     {
       ProductsDAL product = new ProductsDAL();
       product.Product_ID = item["Product_ID"].ToString();
       product.ProductDescr = item["ProductDescr"].ToString();
       bPList.Add(product);
     }
     return bPList;
  }
