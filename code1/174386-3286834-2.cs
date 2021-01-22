    ArticleFrequency = (from tag in story.Descendants("tag")
                        select new
                        { 
                            Key = (string)tag.Element("name"),
                            Value = (int)tag.Element("count")
                        }).Select(item => new MyCustomObject() 
                                              {
                                                  MyPropertyOne = item.Key,
                                                  MyPropertyTwo = item.Value
                                              })
