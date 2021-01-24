    public class CommentRepository: ICommentRepository //Only if you have the interface
    {
        (...)
        public Comment ReturnLast()
        {
            return //do the query here or use your context
        }
    }
