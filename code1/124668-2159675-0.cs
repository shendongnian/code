        var query = list.Select(x => new { x.Name, RO = x.ReportingOfficer1 })
                        .Union(list.Select(x => new { x.Name, RO = x.ReportingOfficer2 }))
                        .Union(list.Select(x => new { x.Name, RO = x.ReportingOfficer3 }));
        var grouped = query.GroupBy(y => y.RO);
        foreach (var group in grouped) {
            foreach (var item in group) {
                Console.WriteLine(String.Format("{0}: {1}", item.RO, item.Name));
            }
        }
