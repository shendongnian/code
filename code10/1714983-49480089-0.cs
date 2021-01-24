            var objects = /*your enumeration*/;
            var masterPlans = objects
                .GroupBy(x => x.MasterPlanID)
                .Select(x => new
                {
                    x.Key.MasterPlanID,
                    x.Key.MasterPlanID,
                    x.Key.MasterPlanName,
                    x.Key.MasterPlanTypeID,
                    x.Key.MasterPlanTypeName,
                    x.Key.MasterPlanMaxDuration,
                    x.Key.MasterPlanMinDuration,
                    Subjects = x
                        .GroupBy(y => y.SubjectId)
                        .Select(y => new
                        {
                            y.Key.SubjectID,
                            y.Key.SubjectName,
                            Activities = y
                                .GroupBy(z => z.ActivityID)
                                .Select(w => new 
                                {
                                    w.Key.ActivityID,
                                    w.Key.ActivityName
                                })
                        })
                });
