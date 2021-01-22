    // delete comment method
    private void DeleteComment()
    {
    
                if(Boolean.Parse(Request.QueryString["confirm"])
                {
                int commentid = Int32.Parse(Request.QueryString["c"]);
    
                // call our delete method
                DB.DeleteComment(commentid);
}
    
    }
