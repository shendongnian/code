    SqlHelper.ExecuteNonQuery(connectinString,
         CommandType.StoredProcedure, "[dbo].[Save]", new SqlParameter[]
             {
                 new SqlParameter("Identity", item.Identity),
                 new SqlParameter("Name", item.Name),
                 new SqlParameter("Title", item.Title)
             }); 
