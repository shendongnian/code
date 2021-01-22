    Product product = new Product { Blah, Blah, Blah };
    bool flag = false;
    for (int i = 0; i < 5; i++)
    {
        Product_Receipes pr = new Product_Receipes 
                                      { Prodcut = product, IsFeatued = flag };
        pr.Receipes.Add(new Receipe()); 
        pr.Receipes.Add(new Receipe());
        flag = !flag;
    }
    Context.SaveChanges();
