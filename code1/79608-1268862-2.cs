        var attributes = DataEventAttribute.GetByQueryExpression(context)
                         .Where(a => a.DataEventKeyID ==1)
                         .Where(predicate);
        var initialQuery = from dataEvent in DataEvent.GetByQueryExpression(context)
                           join attribute in attributes
                           select new
                           {
                               ID = dataEvent.DataEventID,
                               PluginID = dataEvent.DataOwnerID,
                               TimeStamp = dataEvent.DataTimeStamp,
                               DataEventKeyID = attribute.DataEventKeyID,
                               ValueString = attribute.ValueString,
                               ValueDecimal = attribute.ValueDecimal
                           };
