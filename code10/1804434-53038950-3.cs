    public int ComputeMatches()
    {
        var dicTwo = ListTwo.ToLookup(z => z.ProductID);
    
        var matched = (from listOne in ListOne
                       let matches = dicTwo[listOne.ProductID]
                       let sum = matches.Sum(m => m.Quantity * m.GlobalQuantity)
                       select new
                       {
                           ProductID = listOne.ProductID,
                           ROQ = listOne.Price,
                           RUQ = listOne.Quantity,
                           RPQ = listOne.GlobalQuantity,
                           RV = listOne.Price * listOne.Quantity * listOne.GlobalQuantity,
                           BMPProduct = matches.OrderBy(m => m.Price).FirstOrDefault(),
                           WAP = sum == 0 ? 0 : matches.Sum(m => m.Quantity * m.GlobalQuantity * m.Price) / sum
                       });
    
        return matched.Where(m => m.WAP != 0).Count();
    }
