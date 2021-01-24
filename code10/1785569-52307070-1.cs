    var performaQuery = db.Database.SqlQuery<Proforma>(qry);
    var viewModels = performaQuery.Select(x => new PerformaViewModel 
    {
      UserId = x.UserId,
      PerformaName = x.Name,
      UserName = x.User.Name
    }).ToList();
