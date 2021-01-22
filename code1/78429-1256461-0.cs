            var post = session.CreateCriteria<BlogPost>()
                .Add(Restrictions.Eq("Id", 1))
                .UniqueResult<BlogPost>();
            var comments = session.CreateCriteria<Comment>()
                .Add(Restrictions.Eq("BlogPostId", 1))
                .Add(Restrictions.Eq("DatePosted", new DateTime(2009, 8, 1)))
                .List<Comment>();
            post.Comments = comments;
