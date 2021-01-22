        select new BlogPostViewModel {
            Title = p.Title,
            Body = p.Body,
            Comments = p.Comments.Where( c => c.Published );
        });
