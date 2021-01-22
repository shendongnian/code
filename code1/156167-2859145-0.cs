    var query = from ta in db.Transactions_Assets.Include("Transaction")
                            let items = new
                            {
                                Weapon = ta.AssetWeapon,
                                Month = ta.Transaction.StartTime.Value.Month,
                                IsIn = ta.IsIn 
                            }
                            group items by items.Weapon into g
                            select new { 
                                Weapon = g.Key,
                                MonthlyFlow = from m in g 
                                        group m by m.Month into mg
                                        select new { Month = mg.Key, 
                                                     Ins = mg.Count( x => x.IsIn == true),
                                                     outs = mg.Count(x => x.IsIn == false)
                                        }
                            };
