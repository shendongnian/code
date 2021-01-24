    var products = productCollection //This is however you are accessing your product db set 
                       .GroupBy(c => new { c.EAN, c.ProductName})
                       .Select(c => new ProductViewModel { 
                           EAN = c.Key.EAN, 
                           ProductName = c.Key.ProductName, 
                           Quantity = c.Count()
                        });
