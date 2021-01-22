     var groups = personnels.GroupBy(p => p.Level);
        personnels.RemoveAll(p => p.Level == 1);
        foreach (var product in groups)
        {
            Console.WriteLine(product.Key);
            foreach (var item in product)
                Console.WriteLine(item.Id + " >>> " + item.FullName + " >>> " + item.Level);
        }
