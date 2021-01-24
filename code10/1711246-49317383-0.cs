    if (predicatePrezzoVendita != null)
    {
        query = query.AsExpandable()
            .SelectMany(articolo =>
                database.ElencoPrezzoVendita
                    .Where(x => articolo.ForeignKeyID == x.ID)
                    .AsExpandable()
                    .Where(predicatePrezzoVendita)
                    .Select(vendita => vendita.Articolo));
    }
