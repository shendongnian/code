    var dateStart = DateTime.Now;
    var dateEnd = DateTime.Now.AddMonths(1);
    var list = new List<Tuple<DateTime, int, int>>(); // structure to store DateTime, New Registratio, New Application   
    for(var i = dateStart; i.Date <= dateEnd.Date;  i = i.AddDay(1))
    {
        list.Add(Tuple.Create(i,
                              db.Registers.Count(r => r.Creationdate.Date == i.Date), 
                              db.IAApplications.Count(r => r.SubmissionDate.Date == i.Date)));
    }
