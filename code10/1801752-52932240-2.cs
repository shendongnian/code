        var result = tbl
            .GroupBy(p => new { p.id, p.name })
            .Select(g => new
            {
               id = g.Key.id,
               name = g.Key.name,
               choice = g.Select(p => 
                 new Choice()
                 {
                   choiceId = p.choiceId
                   choiceName = p.choiceName
                   choiceValue = p.choiceValue
                 })
            }).toList();
