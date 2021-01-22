    FKMModel.FKMEntities ctx = new FKMModel.FKMEntities();
    if(ctx.EnitityKey !=null)
    {
            IQueryable<Comment> CommentQuery =
                from x in ctx.Comment
                where x.SiteID == 101 
                select x;
            List<Comment> Comments = CommentQuery.ToList();
            dl_MajorComments.DataSource = Comments;
            dl_MajorComments.DataBind();
    }
