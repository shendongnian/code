    var objects = /*your enumeration*/;
    var masterPlans = objects
        .GroupBy(x => x.MasterPlanID)
        .Select(x => new
        {
            x.First().MasterPlanID,
            x.First().MasterPlanID,
            x.First().MasterPlanName,
            x.First().MasterPlanTypeID,
            x.First().MasterPlanTypeName,
            x.First().MasterPlanMaxDuration,
            x.First().MasterPlanMinDuration,
            Subjects = x
                .GroupBy(y => y.SubjectId)
                .Select(y => new
                {
                    y.First().SubjectID,
                    y.First().SubjectName,
                    Activities = y
                        .GroupBy(z => z.ActivityID)
                        .Select(w => new 
                        {
                            w.First().ActivityID,
                            w.First().ActivityName
                        })
                })
        });
