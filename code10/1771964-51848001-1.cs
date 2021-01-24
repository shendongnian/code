            var product = new List<PR_Product>
            {
                new PR_Product { ID_Product = 1, Name = "TestName1", Code = "TestCode1", InProduction = true },
                new PR_Product { ID_Product = 2, Name = "TestName2", Code = "TestCode3", InProduction = true },
                new PR_Product { ID_Product = 3, Name = "TestName3", Code = "TestCode3", InProduction = true }
            };
            var productInsurance = new List<PR_ProductInsuranceProduct>
            {
                new PR_ProductInsuranceProduct { ID_ProductInsuranceProduct = 111, ID_Product = 1 },
                new PR_ProductInsuranceProduct { ID_ProductInsuranceProduct = 222, ID_Product = 1 },
                new PR_ProductInsuranceProduct { ID_ProductInsuranceProduct = 333, ID_Product = 3 },
            };
            var result = product
                .GroupJoin(productInsurance,
                    prProduct => prProduct.ID_Product,
                    insuranceProduct => insuranceProduct.ID_Product,
                    (prProduct, insuranceProduct) => new { prProduct, insuranceProduct })
                .SelectMany(arg => arg.insuranceProduct.DefaultIfEmpty(), (prProduct, insuranceProducts) => new { prProduct })
                .GroupBy(arg => new { arg.prProduct.prProduct.ID_Product, arg.prProduct.prProduct.Name, arg.prProduct.prProduct.Code, arg.prProduct.prProduct.InProduction})
                .Select(grouping => new
                {
                    grouping.Key.ID_Product,
                    grouping.Key.Name,
                    grouping.Key.Code,
                    Max_ID_ProductInsuranceProduct = grouping.FirstOrDefault()?.prProduct.insuranceProduct.DefaultIfEmpty().Max(insuranceProduct => insuranceProduct?.ID_ProductInsuranceProduct)
                });
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
