        var groups = Elements
            .GroupBy(a => new {a.A})
            .Select(g1 => new {
                A = g1.Key, 
                Groups = g1
                .GroupBy(b=> new {b.B})
                .Select(g2 => new {
                    B = g2.Key,
                    Groups = g2
                    .GroupBy(c => new {c.C})
                    .Select(g3 => new {
                        C = g3.Key,
                        Rows = g3
                    })
                })
            });
        foreach (var groupA in groups)
        {
            Trace.WriteLine(groupA.A);
            foreach (var groupB in groupA.Groups)
            {
                Trace.WriteLine("\t" + groupB.B);
                foreach (var groupC in groupB.Groups)
                {
                    Trace.WriteLine("\t\t" + groupC.C);
                    foreach (var row in groupC.Rows)
                    {
                        Trace.WriteLine("Row: " + row.ToString());
                    }
                }
            }
        }
