     -- One Standard way of doing this is convert your datatable into List<Dictionary<string, object>>. Below is the sample code.
    
    
    public JsonResult Teste()
    {
        using (SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString))
        {
            db.Open();
    
            using (SqlCommand comando = new SqlCommand("select * from USERS", db))
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);  
    
                    var resultado = GetTableRows(dataTable);
    
                    return Json(resultado, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
    
    
    
    
    
    
    public List<Dictionary<string, object>> GetTableRows(DataTable dtData)
    {
                List<Dictionary<string, object>> 
                lstRows = new List<Dictionary<string, object>>();
                Dictionary<string, object> dictRow = null;
     
                foreach (DataRow dr in dtData.Rows)
                {
                    dictRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dtData.Columns)
                    {
                        dictRow.Add(col.ColumnName, dr[col]);
                    }
                    lstRows.Add(dictRow);
                }
                return lstRows;
    }
