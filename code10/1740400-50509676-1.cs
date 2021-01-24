        List<Product> oldList = new List<Product>();
        oldList.Add(new Product(1, "OldDataOne"));
        oldList.Add(new Product(2, "OldDataTwo"));
        oldList.Add(new Product(3, "OldDataThree"));
        oldList.Add(new Product(4, "OldDataFour"));
            
        List<Product> newList = new List<Product>();
        newList.Add(new Product(2, "NewDataTwo"));
        newList.Add(new Product(3, "NewDataThree"));
            
        oldList.Where(x => newList.Any(y => y.id == x.id))
            .Select(z => oldList[oldList.IndexOf(z)].url = newList.Where(a => a.id == z.id).FirstOrDefault().url).ToList();
