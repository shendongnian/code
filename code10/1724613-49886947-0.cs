    public JsonResult Teste()
    {
        using (SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexao"]     .ConnectionString))
      {
        db.Open();
        using (SqlCommand comando = new SqlCommand("select * from USERS", db))
        {
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);  
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
      }
    }
