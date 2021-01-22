    // create and save an entity
    var u = new User{ Name="foo", SignupDate=DateTime.Now };
    session.Save( u );
    
    // fetch and update entity
    var post = session.Get<Post>( 42 );
    post.Tags["foo"]++;
    session.Save( post );
    // save a related item for an entity
    post.Tags.Add( new Tag("Name")); 
    session.Save( post );
