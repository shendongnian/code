    blah.GroupBy(sk => sk.SID) // Group
        .Select(sg => new SomeClass // Select into SomeClass
        {
          SID = sg.Key.SID,
          Group = sg.GroupBy(ak => ak.AGroup) // Group
                    .Select(ag => new SomeGroup // Select into SomeGroup
                     {
                        AGroup = ag.Key.AGroup,
                        Category = ag.GroupBy(ck => ck.Category)  // Group
                                     .Select(cg => new SomeCategory  // Select into SomeCategory
                                      {
                                         Category = cg.Key.Category,
                                         Platform = cg.GroupBy(pk => pk.Platform) // Group
                                                      .Select(pg => new SomePlatform // Select into SomePlatform
                                                       {
                                                          Platform = pg.Key.Platform,
                                                          Count = pg.Sum(c => c.TotalCount)
                                                       })
                                      })
                     })
        });
