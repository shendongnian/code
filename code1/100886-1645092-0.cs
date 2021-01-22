    public static void MergeFields(IEnumerable<TYPE1> persistedValues, IEnumerable<TYPE1> newValues)
    {
        var leftIds = persistedValues.Select(x => x.Id).ToArray();
        var rightIds = newValues.Select(x => x.Id).ToArray();
    
        var toUpdate = rightIds.Intersect(leftIds).ToArray();
        var toAdd = rightIds.Except(leftIds).ToArray();
        var toDelete = leftIds.Except(rightIds).ToArray();
    
        foreach(var id in toUpdate){
            var leftScope = persistedValues.Single(x => x.ID == id);
            var rightScope = newValues.Single(x => x.ID == id);
    
            // Map appropriate values from rightScope over to leftScope
        }
    
        foreach(var id in toAdd) {
            var rightScope = newValues.Single(x => x.ID == id);
            // Add rightScope to the repository
        }
    
        foreach(var id in toDelete) {
            var leftScope = persistedValues.Single(x => x.ID == id);
            // Remove leftScope from the repository
        }
    
        // persist the repository
    }
