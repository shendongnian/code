            return from revision in dataContext.Revisions
                   where revision.BranchID == destinationBranch.BranchID - 1 && !revision.HasBeenMerged
                   group revision by new { revision.TaskSourceCode, revision.TaskSourceID }
                       into grouping
                       orderby grouping.Key.TaskSourceCode, grouping.Key.TaskSourceID ascending
                       select (ITask)new Task(grouping.Key.TaskSourceCode, grouping.Key.TaskSourceID);
