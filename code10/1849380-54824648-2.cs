c#
    string commentId = a.Text;
    using (SqlConnection con = new SqlConnection(ConfigurationManager
                .ConnectionStrings["ForumDatabaseConnectionString"].ConnectionString))
    {
        con.Open();
        string sql = "DELETE FROM Comment WHERE Comment.commentId = @commentid";
        using(SqlCommand cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@commentid", commentId);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
As you can see, there is a fair amount of code for such a simple operation.  You may wish to take a look at [dapper][1], which will remove a lot of these issues.  There are many libraries to help you, which are off-topic here, but its a lightweight, popular one
  [1]: https://github.com/StackExchange/Dapper/
