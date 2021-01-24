    {
        var someThingValues = value as ICollection<ISomeThing>; // <-- this results in null
        foreach (var someThingInstance in someThingValues)
        {
            if(someThingInstance.IsSomeCondition)
            {
                // Do the thing again
            }
        }
    }
