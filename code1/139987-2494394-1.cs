    var q = from r in Results
            group p.Unit by new { ID = p.ID, OptionName = p.OptionName } into g
            select new results() {
                ID = g.Key.ID,
                OptionName = g.Key.OptionName,
                NumberOfSelections = g.Count(),
                UnitTotal = g.Sum()
            };
