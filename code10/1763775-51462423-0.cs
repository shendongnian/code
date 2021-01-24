    var res=(from DI in msaDBContext.OT_BackendUpdate_DataItem
                                    .Where(x=>x.iDataTypeID==8)
             join DIS in msaDBContext.OT_BackendUpdate_DataItemStatus
                                     .Where(x=>x.iDataItemCurrentStatusID==1)
                                     .GroupBy(x=>new 
                                                 {            
                                                  x.iDataItemID,
                                                  x.iDataItemCurrentStatusID,
                                                  x.dDateEffective
                                                 })
                                     .Select(x=>new 
                                                {
                                                 iDataItemID=x.key.iDataItemID,
                                 iDataItemCurrentStatusID=x.key.iDataItemCurrentStatusID,
                                                 dDateEffective=x.Max(y=>y.dDateEffective)
                                                 })
             on DI.iDataItemID equals DIS.iDataItemID
             join msaDBContext.OT_BackendUpdate_RefDataItemStatus RDIS
             on DIS.iDataItemCurrentStatusID equals RDIS.iDataItemCurrentStatusID
             select new {DI,DIS})
             .Select(x=>new 
                        {
                          iDataItemID=x.DI.iDataItemID,
                          iDataTypeID=x.DI.iDataTypeID,
                          iDataItemCurrentStatusID=x.DIS.iDataItemCurrentStatusID
                         }).ToList();
