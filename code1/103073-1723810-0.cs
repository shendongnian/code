    private SimpleObject[] GetSimpleObjectUsingSodaAgainstAProperty(int[] matchingIds, IObjectContainer db)
    {
        SimpleObject[] returnValue = new SimpleObject[matchingIds.Length];
    
        for (int counter = 0; counter < matchingIds.Length; counter++)
        {
            var query = db.Query();
            query.Constrain(typeof(SimpleObject));
            query.Descend("Id").Constrain(matchingIds[counter]);
            IObjectSet queryResult = query.Execute();
            if (queryResult.Count == 1)
                returnValue[counter] = (SimpleObject)queryResult[0];
        }
    
        return returnValue;
    }
