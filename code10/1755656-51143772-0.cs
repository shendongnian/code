    var ans = Child.GroupBy(c => c.HeaderId)
                    .Where(cg => {
                        var maxRound = cg.Max(c => c.Round);
                        return cg.Where(c => c.Round == maxRound).All(c => c.Code != "B");
                    })
                    .Count();
