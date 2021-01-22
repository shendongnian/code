    var groups = anaList.Where( p => p.Year > 2007 );  // limit year scope
                        .GroupBy( g => g.NumberOfUnitsSold > 30000
                                         ? "Top"
                                         : (g.NumberOfUnitSold >= 10000
                                              ? "Average"
                                              : "Poor" );
    
    foreach (var group in groups)
    {
        Console.WriteLine( "{0} Movement", group.Key );
        foreach (var product in group.OrderByDescending( p => p.NumberOfUnitsSold ))
        {
             Console.WriteLine( "{0} {1} {2}", product.ProductCode, product.Year, product.NumberofUnitsSold );
        }
    }
