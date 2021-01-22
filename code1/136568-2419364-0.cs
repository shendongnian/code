    1. public List<ProductsDAL> GetAllProducts(string sqlQuery)
    2. {
    3.     DataSet dsinsert = GetDataSet(sqlQuery, "tblProducts");
    4.     List<ProductsDAL> bPList = new List<ProductsDAL>();
    5.     ProductsDALforeach (DataRow item in dsinsert.Tables[0].Rows)
    6.     {
    7.       this.Product_ID = item["Product_ID"].ToString();
    8.       this.ProductDescr= item["ProductDescr"].ToString();
    9.       bPList.Add(this);
    10.     }
    11.    return bPList;
    12. }
