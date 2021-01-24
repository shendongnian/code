    var flattenedResult = result.Select(part => part.AliasPartNumber.Select(alias => new 
                                                                                     { 
                                                                                         CleanPartNo = part.CleanPartNo, 
                                                                                         Description = part.Description,
                                                                                         AliasPartNo = alias.AliasPartNo
                                                                                     })
                                .SelectMany(part => part);
