    var days = DateHelper.EachDay( startDate, endDate );
    var activeDaysIsLogicCorrectFlags = db.Operations
        // get days that are "active"
        .Where( op => op.IsActive && days.Contains( op.Day ) )
        // join with ObjectA's to filter for active ObjectA's
        // is there a nav property you could use instead?
        // use GroupJoin for use with `Any(...)` in results
        .GroupJoin( db.ObjectA, op => op.Day, oa => oa.Day, ( op, oaGroup ) => new
            {
                //Operation = op,
                // projecting Operation.Day since that's what your foreach loop is using
                Day = op.Day,
                IsLogicACorrect = oaGroup.Any( oa => oa.ObjectACount == 5 ),
                // if IsLogicBCorrect can be determined from the collection of ObjectA's:
                //IsLogicBCorrect = oaGroup.Any( oa => oa.ObjectBCount == 3 ),
            } );
