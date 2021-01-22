    return flatSource.Select((item, index) => 
                         new SubregionWithRegion
                         {
                           Region = flatSource.Take(index + 1)
                                              .LastOrDefault(SomeRegionDictionary.ContainsKey) ?? "",
                           SubRegion = item
                         })
                      .Where(srwr => !SomeRegionDictionary.ContainsKey(srwr.SubRegion));
