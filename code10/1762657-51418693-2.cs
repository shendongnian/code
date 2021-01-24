    var items = from p in productsList
                from c in customerList
                select new ProductDetailDto
                {
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName
                    CustCode = c.Customer.CustomerCode,
                    CustName = c.Customer.CustomerName,
                    CustBranchId = c.Customer.CustomerBranchId,
                };
    return items.ToArray();
