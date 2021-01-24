    var query = from product in products
            from property in typeof(Product).GetProperties()
            join toCompare in selectedProductAttributes on property.Name equals toCompare
            let temp = new {
                Name = property.Name,
                Value = property.GetValue(product)
            }
            group temp by temp.Name into gg
            select new
            {
                Name = gg.Key,
                IsDuplicated = gg.Count() > 1
            };
