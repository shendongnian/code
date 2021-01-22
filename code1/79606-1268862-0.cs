        var someSetOfIDs = new List<int>() {1, 2, 3, 4, 5};
        // queryPerID will have type IEnumerable<IQueryable<'a>>
        var queryPerID = from id in someSetOfIDs
                         select (
                           from dataEvent in DataEvent.GetByQueryExpression(context)
                           join attribute in DataEventAttribute.GetByQueryExpression(context)
                             on dataEvent.DataEventID
                                      equals attribute.DataEventID
                           where attribute.DataEventKeyID == 1
                                   && (int)attribute.ValueDecimal == id // Changed from Contains
                           select new
                           {
                               ID = dataEvent.DataEventID,
                               PluginID = dataEvent.DataOwnerID,
                               TimeStamp = dataEvent.DataTimeStamp,
                               DataEventKeyID = attribute.DataEventKeyID,
                               ValueString = attribute.ValueString,
                               ValueDecimal = attribute.ValueDecimal
                           });
        // For each of those queries, we an equivalent final queryable
        var res = from initialQuery in queryPerID
                  select (
                      from dataEvent in DataEvent.GetByQueryExpression(context)
                      where initialQuery.GroupBy(x => x).Select(x => x.Key.ID).Contains(dataEvent.DataEventID)
                      select new
                      {
                          BasicData =
                              attributeBaseQuery.Where(
                              attrValue =>
                                  attrValue.DataEventID == dataEvent.DataEventID &&
                                  attrValue.DataEventKeyID == (short) DataEventTypesEnum.BasicData).FirstOrDefault().
                                  ValueString
                      }) into finalQuery
                  from x in finalQuery
                  select x;
        var finalResult = finalQuery.Take(100).ToList();
