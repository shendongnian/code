    public ActionResult AddComment(string comment, int feedID)
        {
            Comment newComment       = new Comment();
            newComment.Feed_FK_ID    = feedID;
            newComment.Comment_Text  = comment;
            DB.Comments.Add(newComment);
            DB.SaveChanges();
            List<Comment> myComments = DB.Comments.Where(a => a.Feed_FK_ID == 
             feedID).ToList();
    
            CommentViewModel viewModel = new CommentViewModel
            {
                CommentV = myComments
            };  
    
            return PartialView("_AddedComments",viewModel );
            }
