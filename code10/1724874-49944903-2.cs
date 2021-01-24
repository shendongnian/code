    OrderModel Model;
    int OrderId;
    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
       //Call a method in the View Model which calls a WCF service
       //to get the OrderCase object out of our database and into the
       //Order object in the model
       var tempModel = new OrderModel();
       tempModel = await WcfService.GetOrder(OrderId);
       Model.Order = tempModel;
       //Setting the ViewModel's property only when getting order is completed
       //Once this returns all the bindings start evaluating
    }
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
       SetUndirty();
    }
    public override void TextBoxSetDirty(object sender, TextChangedEventArgs e)
    {
        //one of these exists for each type of control I use
        //this gets triggered when the text changes due to the model changing
        SetDirty();
    }
    public void SetDirty()
    {
        Model.Dirty = true;
    }
