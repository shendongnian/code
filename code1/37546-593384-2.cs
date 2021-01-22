    var contents = nodes.Where( n => n.Name == "NodeA")
                        .Select( node => new { desc = node.Attribute("desc")
                                                          .Value,
                                              category = node.Attribute("category")
                                                              .Value
                                             }
                         );
    var desc = contents.desc;
    var category = contents.category;
                                              
