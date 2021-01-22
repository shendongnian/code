     public class nokernokDAL
     {
         string connectionString;
    
         public nokernokDAL()
         {
             ConnectionString = EPiServer.Global.EPConfig["EPsConnection"].ToString();
         }
     
         public void addNewComment(int userID, int pageID, string title, string comment)
         {
             string query = "INSERT INTO dbo.nokernok_kommentarer (userID, pageID, commentTitle, comment) " +
                            "VALUES ("+ userID +", "+ pageID +", '"+ title +"', '"+ comment +"')";
     
             using (SqlConnection conn = new SqlConnection(_connString))
             {
                 SqlCommand cmd = conn.CreateCommand();
                 cmd.CommandText = Query;
                 conn.Open();
                 cmd.ExecuteNonQuery();
             }
         }
     }
