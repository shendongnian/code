    var oData = (from c in oDb.CustomerAdditionalInfos
                 where c.CustomerNumber != null
                 select new 
                 {
                      CustomerNumber = c.CustomerNumber
                 }).Union
                     (from d in oDb.CustomerDocument
                      where d.CustomerNumber != null
                      select new
                      {
                          CustomerNumber = d.CustomerNumber
                      }).Union
                          (from l in oDb.CustomerLink
                           where l.CustomerNumber != null
                           select new
                           {
                               CustomerNumber = l.CustomerNumber
                           }).Union
                                (from i in oDb.CustomerImage
                                 where i.CustomerNumber != null
                                 select new
                                 {
                                     CustomerNumber = i.CustomerNumber
                                 }).OrderBy(c => c.CustomerNumber);
                             
