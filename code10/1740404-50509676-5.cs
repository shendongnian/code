        List<Product> oldList = new List<Product>();
        for (int i = 0; i < 10000; i++)
        {
            oldList.Add(new Product(i, "OldData" + i.ToString(), "OldData" + i.ToString() + "-other"));
        }
        List<Product> newList = new List<Product>();
        for (int i = 0; i < 5; i++)
        {
            newList.Add(new Product(i, "NewData" + i.ToString(), "NewData" + i.ToString() + "-other"));
        }
            
