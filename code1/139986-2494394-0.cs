    var q = from r in Results
            group p.Unit by new { ID = p.ID, OptionName = p.OptionName } into g
            select new {
                ID = g.Key.ID,
                OptionName = g.Key.OptionName,
                Selections = g.Count(),
                Units = g.Sum()
            };
