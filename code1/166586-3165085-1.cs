            var vGroup = from p in Products
                         group p by new { p.ProductId, p.VariantId }
                             into g
                             from i in g
                             select new
                             {
                                 i.ProductId,
                                 i.VariantId,
                                 VariantCount = g.Count()
                             };
            var pGroup = from p in vGroup
                         group p by new { p.ProductId }
                             into g
                             from i in g
                             select new
                             {
                                 i.ProductId,
                                 ProductCount = g.Count(),
                                 i.VariantId,
                                 i.VariantCount
                             };
            var result = pGroup.OrderBy(p => p.ProductId).ThenBy(p => p.VariantId);
