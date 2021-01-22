    using (SqlConnection cn = new SqlConnection())
    {
         using (SqlTransaction tr = cn.BeginTransaction())
         {
          //some code
          tr.Commit();
         }
    }
