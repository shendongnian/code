    public IActionResult PostDetail(string postId)
    {
      var post = _postRepository.GetPostById(postId);
      var comment = _commentRepository.GetCommentByPostId(postId);
      // MVVM model return to the view
      var vM = new PostVM 
      {
        Post = post,
        Comment = comment
      }
    }
