    public void DeleteComment(int commentId)
    {
         using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ForumDatabaseConnectionString"].ConnectionString))
            {
                con.Open();
                string sql = "DELETE FROM Comment WHERE Comment.commentId = @commentid";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@commentid", commentId);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                    
            } 
    }
