    var posts = from p in db.Posts
                 .Include("Site")
                 .Include("PostStatus")
                where p.Public == false
                select p);
    
    if (!chkShowIgnored.Checked) {
        posts = posts.Where(p => p.PostStatus.Id != 90);
    }
    var finalQuery = posts.OrderBy(p => p.PublicationTime);
