    protected void lds_Selecting(object sender, LinqDataSourceSelectEventArgs args)
    {
            Store.Service myProducts = new Store.Service();  
            args.Result  = myProducts.getProductList();     
    }
