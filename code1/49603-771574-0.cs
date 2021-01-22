    var qry = from row in db.SomeUdfQuery(someArgs)
              join comment in db.Comments
              on row.CommentID equals comment.CommentID
              select new {Comment = comment, row.ArbitraryText};
    foreach(var record in qry) {
        record.Comment.ArbitraryText = record.ArbitraryText ;
    }
    return qry.Select(x=>x.Comment).ToList();
