    //1. This line gets an instance of a List<Games> (or something roughly like that)
    GameLevel retVal = new GameLevel(GetGames(gameid, isdateroot, startdate, enddate, iscurrent, isdatesort, requestfrom));
    //2. This line gets the GameTypeIds for the flagged Branch
    var assignments =GetByBranchId(SessionManager.LoggedBranch.BranchIDb => b.Flag);
    //3. self explanatory. 'If there is anything in the assignment variable'
    if (assignments.Any())
    {
        //4. Get a list of GameTypeId values from assignments
        var gameTypes = assignments.Select(x => x.GameTypeId.ToString()).ToList();
        //5. Here's where I think you went wrong
        //5. This line gets the Games where gameTypes contains the GameTypeId in retVal.
        retVal.Rows = retVal.Rows.Where(x => gameTypes.Contains(x.GameTypeID)).ToList();
    }
    return retVal;
