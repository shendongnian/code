       public class PriceCalculator
        {
            public List<OrderPackage> CalculateCheapestPrice(Int32 AmountOfLicenses, 
                List<PriceRange> PriceRanges, out Double Total)
            {
                List<OrderPackage> result = new List<OrderPackage>();
                Total = 0;
    
                Int32 AmountsOfLicensesleft = AmountOfLicenses;
    
                PriceRanges.Sort(ComparePrice);
    
                for (int i = 0; i < PriceRanges.Count; i++)
                {
                    for (int j = PriceRanges[i].MaxAmount; j >= PriceRanges[i].MinAmount; j--)
                    {
                        if (j <= AmountsOfLicensesleft)
                        {
                            OrderPackage Order = new OrderPackage();
                            Int32 AmountOfThisPackage = AmountsOfLicensesleft / j;
                            //Int32 AmountForThisPrice = Convert.ToInt32(Math.Floor(tmp));
    
                            Order.PriceRange = PriceRanges[i];
                            Order.AmountOfLicenses = j;
    
                            Total += Order.AmountOfLicenses * Order.PriceRange.PricePerLicense;
    
                            for (int k = 0; k < AmountOfThisPackage; k++)
                            {
                                result.Add(Order);
                            }
    
                            AmountsOfLicensesleft = AmountsOfLicensesleft - (AmountOfThisPackage * j);
                        }
                    }
                }
    
                return result;
            }
    
            private static int ComparePrice(PriceRange x, PriceRange y)
            {
                if (x.PricePerLicense == y.PricePerLicense)
                    return 0;
    
                if (x.PricePerLicense > y.PricePerLicense)
                    return 1;
    
                if (x.PricePerLicense < y.PricePerLicense)
                    return -1;
    
                return 0;
            }
    
            public class OrderPackage
            {
                public PriceRange PriceRange { get; set; }
                public Int32 AmountOfLicenses { get; set; }
            }
    
            public class PriceRange
            {
                public int MinAmount { get; set; }
                public int MaxAmount { get; set; }
    
                public Double PricePerLicense { get; set; }
            }
        }
