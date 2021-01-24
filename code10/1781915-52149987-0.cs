     targetJObject.Merge(sourceJObject, new JsonMergeSettings
        { 
            MergeArrayHandling = MergeArrayHandling.Union
        });
     targetJObject.Merge(sourceJObject, new JsonMergeSettings
        { 
            MergeArrayHandling = MergeArrayHandling.Replace
        });
