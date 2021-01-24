    var viewModels = context.Documents
        .Select(x => new DocumentViewModel
        {
            DocumentId = x.DocumentId,
            Name = x.Name,
            Metas = x.Metas.Select(m => new MetaViewModel
            {
                MetaId = m.MetaId,
                Name = m.Name,
                Value = m.Value
             }).ToList()
        }).Skip(pageNumber*pageSize)
        .Take(PageSize)
        .ToList();
