    var contents = attrs.Where( attr => attr.Name == "category")
                        .Select( attr => attr.Value )
                        .Select( node => new { desc = node.Attributes("desc")
                                                          .Single()
                                                          .Value,
                                               category = node.Attributes("category")
                                                              .Single()
                                                              .Value
                                             }
                         );
    var desc = contents.desc;
    var category = contents.category;
                                              
