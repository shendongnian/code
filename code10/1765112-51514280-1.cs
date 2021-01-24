    var visit = new Visit
    {
        CheckIn = new DateTime(2018, 06, 07, 12, 54, 34),
        CheckOut = new DateTime(2018, 06, 07, 18, 42, 14)
    };
    visit.Activities = new List<Activity>
    {
        new Activity { VisitId = 1 },
        new Activity { VisitId = 1 }
    },
    context.Visits.AddOrUpdate(visit);
