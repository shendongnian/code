        select new BlogPost {
            Title = p.Title,
            Content = p.Content,
            Comments = p.Comments.Where( c => c.Published );
        });
