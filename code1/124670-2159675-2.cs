        var query = officers.SelectMany(
            x => new[] {
                new { x.Name, RO = x.ReportingOfficer1 },
                new { x.Name, RO = x.ReportingOfficer2 },
                new { x.Name, RO = x.ReportingOfficer3 }
            }
        );
        var grouped = query.GroupBy(y => y.RO);
        foreach (var group in grouped) {
            foreach (var item in group) {
                Console.WriteLine(String.Format("{0}: {1}", item.RO, item.Name));
            }
        }
