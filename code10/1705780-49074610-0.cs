    var data = from d in Master.Connection.Familys.Where(x => some conditions).OrderByDescending(d => d.ID)
                       select new Families
                       {
                           Id = d.ID,
                           Surname = d.Surname,
                           Address = d.Address,
                           Cars = ""
                       };
    data.ForEach(f => f.Cars = String.Join(",", Master.Connection.Cars.Where(x => x.FamilyID == item.ID).Select(cr => cr.Name).ToArray()));
