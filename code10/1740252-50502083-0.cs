    var stagedSystemCodes = stagedSystemObjects.Select(x => x.Code).ToList();
    var sourceSystemCodes = sourceSystemObjects.Select(x => x.Code).ToList();
    var codesThatNoLongerExistInSourceSystem = stagedSystemCodes.Except(sourceSystemCodes).ToList();
            
    return stagedSystemObjects
       .Where(stagedSystemObject => 
            codesThatNoLongerExistInSourceSystem.Contains(stagedSystemObject.Code))
       .Select(x =>
       {
           x.ActiveStatus = ActiveStatuses.Disabled;
           x.ChangeReason = ChangeReasons.Edited;
           return x;
       })
       .ToList();
