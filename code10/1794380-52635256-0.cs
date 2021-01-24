    var qry = db.Elements
                .Select(c => new ElementNameViewModel
                {
                    Symbol = c.Symbol,
                    Name = c.Name
                })
                .OrderBy(e => e.Symbol);
    var elements = new ElementNameList();
    elements.AddRange(qry);
