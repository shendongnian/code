    var activeDaysIsLogicCorrectFlags =
        <existing logic from above>
        .GroupJoin( db.ObjectB, at => at.Day, ob => ob.Day, ( at, obGroup ) => new
            {
                // project all previous results
                at.Day,
                at.IsLogicACorrect,
                // new flag
                IsLogicBCorrecet = obGroup.Any( ob => ob.ObjectBCount == 3 ),
            } );
