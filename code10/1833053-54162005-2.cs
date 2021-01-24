    StaffMember X = new StaffMember
    {
        TimeByDateByStaff = new List<TicketWorkRecord>()
                            {
                                new TicketWorkRecord(DateTime.Today.Date, 3.5M),
                                new TicketWorkRecord(DateTime.Today.Date.AddDays(2), 4.5M)
                            }
    };
    StaffMember Y = new StaffMember
    {
        TimeByDateByStaff = new List<TicketWorkRecord>()
                            { new TicketWorkRecord(DateTime.Today.Date.AddDays(1), 6M) }
    };
    var staffMembers = new List<StaffMember>() { X, Y };
