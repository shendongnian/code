    var query = table1
            .Where(t1 => t1.MyID == 1)
            .Select(t1 => new MyViewModel()
            {
                A = t1.A,
                B = t1.B,
                C = t1.C,
                D = table2.Where(t2 => t2.MyID == t1.MyID).OrderByDescending(x => x.MyDate).Select(x => x.D).FirstOrDefault(),
                E = table2.Where(t2 => t2.MyID == t1.MyID).OrderByDescending(x => x.MyDate).Select(x => x.E).FirstOrDefault(),
                F = table2.Where(t2 => t2.MyID == t1.MyID).OrderByDescending(x => x.MyDate).Select(x => x.F).FirstOrDefault(),
                G = table3.Where(t3 => t3.MyID == t1.MyID).Select(c => new TModel()
                {
                    Col1 = c.Col1,
                    Col2 = c.Col2,
                }).ToList(),
                H = table4.Where(t4 => t4.MyID == t1.MyID).Select(l => new PModel()
                {
                    Col1 = l.Col1,
                    Col2 = l.Languages.Col2,
                }).ToList(),
            });
