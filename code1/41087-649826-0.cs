            double highestprice = orderbook.asks[asklength].price;
            List<PriceLevel> difflist = new List<PriceLevel>(fullorderbook.asks.Except(orderbook.asks));
            fullorderbook.asks.Clear();
            fullorderbook.asks.AddRange(orderbook.asks);
            //fill the shifted orders
            fullorderbook.asks.AddRange(
                (difflist.FindAll((x) =>
            {
                //shifted order
                return x.price > highestprice;
            }
                )));
    
            //fill the deleted orders
            changes.AddRange(
                (difflist.FindAll((x) =>
            {
                //deleted order
                return x.price < highestprice;
            }).ConvertAll((y)=>
            
            {
                return new CapturedLevel(0, y.price, -1*y.volume);
            }
            )));
