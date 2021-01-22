    var options = new DataLoadOptions();
    options.AssociateWith<Blog>(b => 
        b.Posts.Where(
            p1 => p1.SomeColumn == b.Posts.Max(p2 => p2. SomeColumn)
        ));
