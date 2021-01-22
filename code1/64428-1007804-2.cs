    var lQuery =
                MyClass.GetList()
                    .GroupBy(pArg => pArg.PO)
                    .Select(pArg => new
                       {
                           Test = pArg.Select((pArg1, pId) => 
                                              new {ID = (pId / 5), 
                                                   pArg1.PO, pArg1.SKU, pArg1.Qty})
                                           .GroupBy(pArg1 => pArg1.ID)
                                           .Select(pArg1 => 
                                                   pArg1.Aggregate(pArg.Key.ToString(),
                                                                   (pSeed, pCur) => 
                                                                   pSeed + pCur.SKU + ","))
                            });
