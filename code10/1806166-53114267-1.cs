    dynamic source = JsonConvert.DeserializeObject<ExpandoObject>(data);
    IEnumerable<dynamic> items = source.Items;
    IEnumerable<dynamic> companies = source.Companies;
    var result = items
        .Select(item => new
        {
            item.Ref,
            item.FaceValue,
            BuyerId = item.BuyerRef,
            Buyer = companies.FirstOrDefault(company => item.BuyerRef == company.CompanyId),
            SupplierId = item.SupplierRef,
            Supplier = companies.FirstOrDefault(company => item.SupplierRef == company.CompanyId)
        })
        .GroupBy(i => new { i.Ref, i.Buyer, i.Supplier })
        .Select(group => new
        {
            group.Key.Ref,
            BuyerId = group.Key.Buyer.CompanyId,
            group.Key.Buyer,
            SupplierId = group.Key.Supplier.CompanyId,
            group.Key.Supplier,
            Lines = group.Select(i => new { i.Ref, i.FaceValue }).ToArray(),
            FaceValue = group.Sum(i => (decimal) i.FaceValue)
        })
        .ToArray();
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
