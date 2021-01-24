                var stagedSystemCodes = stagedSystemObjects.Select(x => x.Code);
                var sourceSystemCodes = sourceSystemObjects.Select(x => x.Code);
                var codesThatNoLongerExistInSourceSystem = stagedSystemCodes.Except(sourceSystemCodes).ToArray();
                var y = stagedSystemObjects.AsParallel()
                   .Where(stagedSystemObject =>
                        codesThatNoLongerExistInSourceSystem.Contains(stagedSystemObject.Code))                  
                   .Select(x =>
                   {
                       x.ActiveStatus = ActiveStatuses.Disabled;
                       x.ChangeReason = ChangeReasons.Edited;
                       return x;
                   }).ToArray();
