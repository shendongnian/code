    public IHttpActionResult Post(CombinedPostAndImage combinedPost)
    {
      /* create your Post from the combinedPost  */
        var post = new Post
        {
            post.Property1 = combinedPost.Property1,
            /* more properties */
        };
        int postid = Convert.ToInt32(postDB.AddPost(userpost));
        var filename= string.Format("{0}_{1}", postid, Guid.NewGuid().ToString());
            //Convert Base64 Encoded string to Byte Array.
        using (var ms = new MemoryStream(Convert.FromBase64String(combinedPost.FileBody)))
        {
            var uploader = new Upload();
            uploader.UploadFile(filename, ms);
        }
    }
