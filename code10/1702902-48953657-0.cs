    var samplePriceList = PriceCollection.GroupBy(priceEntity=> priceEntity.MarketId).ToDictionary(g=> g.Key,g=> g.ToList());
            foreach (var tradeEntity in OrderEntityColection)
            {
                var price = samplePriceList[tradeEntity.MarketId].FirstOrDefault(obj => obj.Audit == tradeEntity.Audit);
                if (price != null)
                {
                    count+=1;
                }
            }
