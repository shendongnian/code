    public List<ProductsDAL> GetAllProducts(string sqlQuery)
      {
         DataSet dsinsert = GetDataSet(sqlQuery, "tblProducts");
         List<ProductsDAL> bPList = new List<ProductsDAL>();
         ProductsDAL p = null;
         ProductsDALforeach (DataRow item in dsinsert.Tables[0].Rows)
         {
           p =new ProductsDAL();
           p.Product_ID = item["Product_ID"].ToString();
           p.ProductDescr= item["ProductDescr"].ToString();
           bPList.Add(p);
         }
         return bPList;
      }
