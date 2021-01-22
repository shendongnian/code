    PageContents = (from pc in el.Elements()
                                    where pc.Name.LocalName == "revision"
                                    select new PageContent()
                                    {
                                       Content = pc.Elements().Where(e => e.Name.LocalName=="text").First().Value,
                                       Username = pc.Elements().Where(e => e.Name.LocalName == "contributor").First().Elements().Where(e => e.Name.LocalName == "username").First().Value,
                                       DateTime = DateTime.Parse(pc.Elements().Where(e => e.Name.LocalName == "timestamp").First().Value)
                                    }).ToEntitySet()
