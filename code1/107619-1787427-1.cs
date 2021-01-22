    Products product = new Products { Blah, Blah, Blah };
    bool flag = false;
    for (int i = 0; i < 5; i++)
    {
        Products_Receipes pr = new Products_Receipes 
                                      { Products = product, IsFeatued = flag };
        pr.Receipes.Add(new Receipes()); 
        pr.Receipes.Add(new Receipes());
        flag = !flag;
    }
    Context.SaveChanges();
