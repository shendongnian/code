    public ActionResult Create([Bind(Exclude = "Id")] Artist artist,
                               [Bind(Prefix = "Contact")] Contact contact )
    {
        artist.Contact = contact;
        ...
    }
  
