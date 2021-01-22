    XDocument doc = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),
        new XElement("rss",
            new XAttribute("version", "2.0"),
            new XElement("channel",
                
                new { title="C# in Depth news",
                      link ="http://csharpindepth.com/News.aspx",
                      description = "C# in Depth news items",
                      language = "en-gb",
                      generator = "LINQ",
                      docs = "http://blogs.law.harvard.edu/tech/rss",
                      pubDate = DateTimeOffset.UtcNow.ToString
                          (Rfc822Format, CultureInfo.InvariantCulture),
                      lastBuiltDate = items.First().CreatedDate.ToString
                          (Rfc822Format, CultureInfo.InvariantCulture),
                }.AsXElements(),
                items.Select(item =>
                    new XElement("item",
                        new { title=item.Title, 
                              link=string.Format(LinkFormat, item.NewsItemID), 
                              description=item.Summary,
                              author="skeet@pobox.com",
                              pubDate = item.CreatedDate.ToString
                                  (Rfc822Format, CultureInfo.InvariantCulture)
                        }.AsXElements()
                    )
                )
            )
        )
    );
