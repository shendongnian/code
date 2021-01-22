    var criteria = someCriteriaThatReturnsPersistentEntities;
    var items = criteria.List<IMailOrderAssignee>();
    var projected = items.Select(i => new
                                      {
                                          Prop1 = i.SomeMethod(),
                                          Etc
                                      });
