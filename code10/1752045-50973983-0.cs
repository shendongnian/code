               var query = (from s in db.Sku
                             join sc in db.SkuCombo on s.Sku equals sc.Sku
                             join s2 in db.Sku on sc.SkuId equals s2.Sku
                             where skulist.Contains(s.Sku)
                             select new
                             {
                                 Sku = s.Sku,
                                 SkuQty = s.SkuQty,
                                 ComboSku = s2.Sku,
                                 ComboSkuQty = sc.Qty
                             }).GroupBy(x => x.Sku)
                            .Select(x => new OrderItem()
                            {
                                Sku = x.Key,
                                SkuQty = x.Sum(y => y.SkuQty),
                                ComboItems = x.Select(y => new ComboItem()
                                {
                                    ComboSku = y.ComboSku,
                                    ComboSkuQty = y.ComboSkuQty
                                }).ToList()
                            }).ToList();
