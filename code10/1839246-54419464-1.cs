    var selector = (Part part) => part.AliasPartNumber?.Any() == true
                                      ? part.AliasPartNumber.Select(alias => new 
                                                                             { 
                                                                                 CleanPartNo = part.CleanPartNo, 
                                                                                 Description = part.Description,
                                                                                 AliasPartNo = alias.AliasPartNo
                                                                             })
                                      : new[]
                                        {
                                            new 
                                            { 
                                                CleanPartNo = part.CleanPartNo, 
                                                Description = part.Description,
                                                AliasPartNo = alias.AliasPartNo
                                            }
                                        };
    var flattenedResult = result.Select(selector).SelectMany(item => item);
