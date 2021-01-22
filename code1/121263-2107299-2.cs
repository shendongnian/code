    int postIdInput = 42; // desired post_id to search for
 
    // PostType delcared prior to getting the results
    PostType postType = new PostType()
    {
        PostId = postIdInput,
        PostComments = new List<PostComment>()
    };
    
    // Database interaction starts here...
     // updated SQL statement to use column name aliases for clarity when used by the SqlDataReader
        string sqlStatement = @"SELECT P.post_id As PostId, C.id As CommentId, C.title As Title
                                FROM post As P, comment As C
                                WHERE
                                    P.post_id = @PostId
                                    AND P.post_isdeleted = 0  -- 0 is false
                                    AND C.CommentPostID = P.post_id";
            
     string sqlConnectionString = "..."; // whatever your connection is... probably identical to your L2S context.Connection.ConnectionString
        using (SqlConnection conn = new SqlConnection(sqlConnectionString))
        {
            conn.Open();
            SqlCommand command = new SqlCommand(sqlStatement, conn);
            command.Parameters.AddWithValue("@PostId", postIdInput); // use Parameters.Add() for greater specificity
           
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            // postId was set based on input, but could be set here as well although it would occur repeatedly
            // if desired, uncomment the 2 lines below and there's no need to initialize it earlier (it'll be overwritten anyway)
            //int postId = Int32.Parse(reader["PostId"].ToString());
            //postType.PostId = postId;
            int commentId = Int32.Parse(reader["CommentId"].ToString());
            string title = reader["Title"].ToString();
           
            // add new PostComment to the list
            PostComment postComment = new PostComment
            {
                CommentId = commentId,
                Title = title
            };
            postType.PostComments.Add(postComment);
        }
        
        // done! postType is populated...
    }
    // use postType...
