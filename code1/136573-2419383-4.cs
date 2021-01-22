    public IList<Product> GetProducts(string sortexpression)
    {
      StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ProductName, ProductID");
                sql.Append("   FROM Products ");
                if (!string.IsNullOrEmpty(sortExpression))
                    sql.Append(" ORDER BY " + sortExpression);
    
                DataTable dt = Db.GetDataTable(sql.ToString());
    
                return MakeProducts(dt);
    }
