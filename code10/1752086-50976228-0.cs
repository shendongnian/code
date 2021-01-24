    var practice = _ctx.Practice.SingleOrDefault(p => p.Id == practiceId);
    
    practice.Participations.AddRange(NewParticipations);
    
    Debug.WriteLine(_ctx.Participation.Count()); //note count
    
    await _ctx.SaveChangesAsync();
    Debug.WriteLine(_ctx.Participation.Count()); //count increased
