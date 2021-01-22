    var query = (from t in Transactions
                             group t by new {t.MaterialID, t.ProductID}
                             into grp
                                 select new
                                            {
                                                grp.Key.MaterialID,
                                                grp.Key.ProductID,
                                                Quantity = grp.Sum(t => t.Quantity)
                                            }).ToList();
