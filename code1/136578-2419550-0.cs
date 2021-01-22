    public List<ProductsDAL> GetAllProducts(string sqlQuery) {
        DataSet dsinsert = GetDataSet(sqlQuery, "tblProducts");
    
        return (from row in dsinsert.Tables[0].AsEnumerable()
                select new ProductsDAL {
                    Product_ID = row.Field<string>("Product_ID"),
                    ProductDescr = row.Field<string>("ProductDescr"),
                }).ToList();
    }
