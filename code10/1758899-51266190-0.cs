            public async Task<ActionResult> ShowDetails(int ProductId, string PartId, string SupplierName, string fromSearchString, int? fromPage)
        {
            List<string> DbSupplierList = await _itScopeRepository.GetSupplierByPartId(Convert.ToInt32(PartId));
            var ItScopeProduct = _itScopeRepository.GetProductById(ProductId);
            ItScopeProduct.Supplier = SupplierName;
            ItScopeProduct.SupplierList = DbSupplierList;
            ViewBag.FromSearchString = fromSearchString;
            ViewBag.FromPage = fromPage;
            var obj = await CreateLineChart(DbSupplierList, PartId);
            List<KeyValuePair<string, List<IDataPoint>>> ConvertToInterface = new List<KeyValuePair<string, List<IDataPoint>>>();
            foreach (var item in obj)
            {
                ConvertToInterface.Add(new KeyValuePair<string, List<IDataPoint>>(item.Key, item.Value.ToList<IDataPoint>()));
            }
            ItScopeProduct.DataPoints = ConvertToInterface;
            return View("DetailsView", ItScopeProduct);
        }
