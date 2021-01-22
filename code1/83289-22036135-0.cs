      public static Decimal GetPrice(Decimal price)
                {
                    var DecPrice = price / 50;
                    var roundedPrice = Math.Round(DecPrice, MidpointRounding.AwayFromZero);
                    var finalPrice = roundedPrice * 50;
        
                    return finalPrice;
        
                }
