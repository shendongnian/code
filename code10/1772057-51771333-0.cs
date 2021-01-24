    var result = db.Partenaires
        .Where(p => p.PartenairePrestations.Any(pp => pp.Prestation.NomPrestation == prestation.Value))
        .Select(p => new PartenaireMapItem {
            IdPartenaire = p.IdPartenaire,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Type = p.Type,
            Lat = p.Lat,
            Lng = p.Lng,
            ImageUrl = p.ImageUrl,
            SeDeplace = p.SeDeplace,
            ADomicile = p.ADomicile,
            Prestations = new List<string>(p.PartenairePrestations.Select(y => y.Prestation.NomPrestation))
        }).ToList();
        
    foreach (var row in result) {
        row.NomComplet = row.LastName.ToUpper()[0] + ". " + row.FirstName;
        row.DureeMin = rnd.Next(2, 50);
        row.NoteGlobale = rnd.Next(1, 6);
    }
    return result;
