    var inclusionList = new List<string> { "inclusion1", "inclusion2" };
    var query = myEntities.MyEntity
                         .Select(e => e.Name)
                         .Where(e => e.IsIn(inclusionList));
    var exceptionList = new List<string> { "exception1", "exception2" };
    var query = myEntities.MyEntity
                         .Select(e => e.Name)
                         .Where(e => e.IsNotIn(exceptionList));
