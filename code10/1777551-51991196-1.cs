    List<Stack> Unavailability = new List<Stack>
    {
            new Stack{  Key = "A", StartDate = new DateTime(2018,1,1), EndDate = new DateTime(2018,1,30) },
            new Stack{  Key = "B", StartDate = new DateTime(2018,1,1), EndDate = new DateTime(2018,1,30)},
            new Stack{  Key = "C", StartDate = new DateTime(2018,1,1), EndDate = new DateTime(2018,1,30)}
    };
    
    bool allUnique = Unavailability.Select(_ => new { _.StartDate, _.EndDate }).Distinct().Count() <= 0;
