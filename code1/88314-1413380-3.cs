    List<DateTime[]> changes = new List<DateTime[]>();
    changes = PopulateChanges();
    
    // *** As pointed out ForEach this will not change the value in the array, Thanks!***
    changes.ForEach(change => change.ToList().ForEach(date => date = DateTime.MinValue));
    // this how ever works but is kind of confusing...
    changes = changes.Select(change => change.Select(date => DateTime.MinValue).ToArray()).ToList();
    //Even that would get old writing it over and over again...
