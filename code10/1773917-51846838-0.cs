      public AccessHelper GetAccessHelper(int id)
            {
            using (SqlConnection sqlCon = new SqlConnection("Data Source = QL01; Initial Catalog = SCAM; Integrated Security = True"))
            {
                var accessHelper = sqlCon.Query<AccessHelper>("getAccessHelper", new { id }, commandType: System.Data.CommandType.StoredProcedure);
                return accessHelper;  
            }
        }
