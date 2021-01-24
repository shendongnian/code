    string sql = "SELECT COUNT(AnswerID) FROM Question ........ WHERE ......";
    
    using (var connection = CreateConnection()) {
        using (var cmd = new SqlCommand(sql, connection)) {
            bool exists = (int) cmd.ExecuteScalar() > 0;
            if (exists) {
                Response.Redirect("StudentExamResults.aspx");
            } else {
                // Do the other thing
            }
        }
    }
