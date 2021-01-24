    select new GroupedData()
                         {
                             WZ = grp.Key.WZ,
                             KUNNR = grp.Key.KUNNR,
                             DATA = grp.Key.WZ_DATA,
                             MATERIAL = grp.Count(),
                         }
