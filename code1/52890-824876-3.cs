    using (SvnClient client = new SvnClient())
    {
        client.SetRevisionProperty(new Uri("http://my/repository"), 12345,
                                  SvnPropertyNames.SvnAuthor,
                                  "MyName");
        // Older SharpSvn releases allowed only the now obsolete syntax
        client.SetRevisionProperty(
            new SvnUriTarget(new Uri("http://my/repository"), 12345),
            SvnPropertyNames.SvnAuthor,
            "MyName");
    }
