    db.Partenaires
             .Where(p => p.PartenairePrestations.Any(pp => pp.Prestation.NomPrestation == prestation.Value))
             //note: the change is here
             .ToList()
             .Select(p => new PartenaireMapItem {
                 IdPartenaire = p.IdPartenaire,
                 FirstName = p.FirstName,
                 LastName = p.LastName,
                 NomComplet = p.LastName.Substring(0,1).ToUpper() + ". " + p.FirstName,
                 Type = p.Type,
                 DureeMin = 50,
                 Lat = p.Lat,
                 Lng = p.Lng,
                 ImageUrl = p.ImageUrl,
                 SeDeplace = p.SeDeplace,
                 ADomicile = p.ADomicile,
    
                 Notes = p.NoteClientPartenaires,
                 Prestations = new List<string>(p.PartenairePrestations.Select(y => y.Prestation.NomPrestation))
             }).ToList();
