    public void NotifyObservers()
    {
        foreach(Product product in ProductList)
        {
            if (product is IProductObserver)
            {
                   product.Update(this)
            }
        }
    }
