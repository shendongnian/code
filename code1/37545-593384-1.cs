    var contents = node.Select( node => new { desc = node.Attributes("desc")
                                                          .Single()
                                                          .Value,
                                              category = node.Attributes("category")
                                                              .Single()
                                                              .Value
                                             }
                         );
    var desc = contents.desc;
    var category = contents.category;
                                              
