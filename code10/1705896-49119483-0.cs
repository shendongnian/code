    return stats.GroupBy(x => x.Id).OrderByDescending(x => x.Sum(a => a.Kills))
                .Select(x => new WeaponItem
                {         
                    PossessionTime = DBFunctions.CreateTime(0, 0, x.Sum(p => p.PossessionTime.Ticks) / 10000000))
                });
