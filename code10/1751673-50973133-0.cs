    var finalPriceList = new List<ProductPrice>();
            var productPrices = new List<ProductPrice>();
            foreach (var item in productPrices)
            {
                foreach (var temp in item.Prices)
                {
                    if (temp.PriceKey == "ABC")
                    {
                        var prodPrice = new ProductPrice()
                        {
                            Price = temp.Price,
                            ProductCode = temp.ProductCode
                        };
                        finalPriceList.Add(prodPrice);
                    }
                    else
                    {
                        int min = item.Prices.Min(entry => entry.Price);
                        var lowestPrice = item.Prices.Where(w => w.Price == min).Single();
                        var prodPrice = new ProductPrice()
                        {
                            Price = lowestPrice.Price,
                            ProductCode = lowestPrice.ProductCode
                        };
                        finalPriceList.Add(prodPrice);
                    }
                }
            }
