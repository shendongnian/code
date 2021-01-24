    var qPeoples = Participants.Join(Peoples,
                        pr => pr.PeopleId,
                        pe => pe.Id,
                        (pr, pe) => new { Part = pr, People = pe });
    
    var result = Appointments.Select(app => new
        {
            app.Id,
            app.Subject,
            Participant = String.Join(",", qPeoples.Where(q => q.Part.AppointmentId == app.Id)
                                                    .Select(s => new 
                                                        { FullName = String.Format( "{0} {1}"
                                                            , s.People.Name, s.People.Surname ) } ) )
        }).ToList();
