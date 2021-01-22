    var auta = from jo in
                           (
                               from a in MtAuta.FindAll()
                               join p in DtPoruchy.FindAll() on a equals p.MtAuta into ap
                               from ap2 in ap.DefaultIfEmpty()
                               where ap2.SERVIS >= 3
                               select new
                               {
                                   Cena = ap2.CENA,
                                   Idauto = ap2.ID_AUTA,
                                   Servis = ap2.SERVIS
                               }
                           )
                       group jo by jo.Idauto into g
                       select new
                       {
                           Cena = g.Sum(jo => jo.Cena),
                           IdAuto = g.Key,
                           Servis = g.Max(jo => jo.Servis)
                       };
