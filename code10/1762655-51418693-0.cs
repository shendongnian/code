    var finalList = new List<ProductDetailDto>();
    var customerList = new List<CustomerGroup>();
    
    /// productsList is also type List<ProductDetailDto>();
    
    for (var j = 0; j<= productsList.Count()-1; j++)
    {
        for (int i = 0; i <= customerList.Count() - 1; i++)
        {
            var singleDetail = new ProductDetailDto 
            {
                ProductCode = productsList[j].ProductCode,
                ProductName = productsList[j].ProductName
                // and whatever other properties your product have
            };
    
            // Assemble rest of the info
            singleDetail.CustCode = customerList[i].Customer.CustomerCode;
            singleDetail.CustName = customerList[i].Customer.CustomerName;
            singleDetail.CustBranchId = customerList[i].Customer.CustomerBranchId;
    
            finalList.Add(singleDetail);
        }
    }
    
    return finalList;
