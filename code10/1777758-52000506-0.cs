     var T = dbContext.Table_Application.Join(
                        db.Table_Service,
                        TA=> TA.ServiceId,
                        TS => TA.ServiceId,
                        (TA,TS ) => new { TA, TS }
                        ).Join(
                        db.Table_Product,
                        TA2=> TA2.TA.ProductID,
                        TP => TP.ProductID,
                        (TA2, TP) => new { TA2, TP }
                        ).Where(c => c.TA.Id == "mysessionid").FirstOrDefault();
