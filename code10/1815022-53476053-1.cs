    var Personality = (from p in _ctx.PersonalityType.AsNoTracking()
    where (p.Id == (int) person.personality)
    select new PersonalityTypeModel
    {
          PersonalityDescription = p.Description,
          HTMLContent = p.HTML
    }).SingleOrDefault();   //FirstOrDefault()
    
