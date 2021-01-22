    namespace Madtastic
    {
        public class Comment
        {
            private Madtastic.DataContext mdc;
    	    private Madtastic.Entities.Comment comment;
    
            public Int32 ID
            {
                get
                {
                    return comment.CommentsID;
                }
            }
    
            public Madtastic.User Owner
            {
                get
                {
                    return comment.User;
                }
            }
    
            public Comment(Int32 commentID)
            {            
                mdc = new Madtastic.DataContext();
    
                comment = (from c in mdc.Comments
                               where c.CommentsID == commentID
                               select c).FirstOrDefault();
    
                if (comment == null)
                {
                    comment = new Madtastic.Entities.Comment();
    		    mdc.Comments.InsertOnSubmit(comment);
                }
    
            }
    
            public void SubmitChanges()
            {
    
                mdc.SubmitChanges();
    
            }
    
    
            public void Delete()
            {
                mdc.Comments.DeleteOnSubmit(comment);
    	        SubmitChanges();
            }
        }
    }
