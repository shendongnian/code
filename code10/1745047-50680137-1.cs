    var data = (from l in lines.Skip(1)
               let split = l.Split(',')
               select new
               {
                   ISOName = split[3],
                   ISOCode = split[3]
               }).Distinct()
               .Select(x => new CurrencyDetail
               {
                   ISOName = x.ISOName,
                   ISOCode = x.ISOCode
               };
