    var prestation = queryString.FirstOrDefault();
    // Handle when prestation comes back #null. Is that valid?
    
    var results = db.Partenaires.Where(p => p.PartenairePrestations.Any(pp => pp.Prestation.NomPrestation == prestation.Value))
    //                .ToList() // Avoid .ToList() here... Select the entity properties you need.
        .Select(p => new PartenaireMapItem {
            IdPartenaire = p.IdPartenaire,
            FirstName = p.FirstName,
            LastName = p.LastName,
            // NomComplet = p.LastName.Substring(0,1).ToUpper() + ". " + p.FirstName, // Remove. Make this a computed property in your view model.
            Type = p.Type,
            // DureeMin = 50, // Can remove, can be a computed property.
            Lat = p.Lat,
            Lng = p.Lng,
            ImageUrl = p.ImageUrl,
            SeDeplace = p.SeDeplace, // Ok if a String/value. 
            ADomicile = p.ADomicile, // Ok if a String/value.
    
            Notes = p.NoteClientPartenaires, // Ok if a String/value.
            Prestations = p.PartenairePrestations.Select(y => y.Prestation.NomPrestation).ToList(); // Assuming this is retrieving the names of presentations. List<string>.
        }).ToList();
    
    return results;
