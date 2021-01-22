            var auta = from e in
                           (from a in DtPoruchy.FindAll()
                            where a.SERVIS >= 3
                            join p in MtAuta.FindAll() on a.MtAuta equals p.Id into ap
                            from ap2 in ap.DefaultIfEmpty()
                            select new
                            {
                                Cena = ap.cena,
                                IdAuta = a.MtAuta,
                                Servis = a.servis
                            })
                       group e by e.IdAuta into g
                       select new
                       {
                           Cena = g.Sum(e => e.cena),
                           IdAuta = g.Key,
                           Servis = g.Max(e => e.servis)
                       };
