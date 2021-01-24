    public static void PopulateContainer(Record rec) {
        if ((rec.OrderID != _orderID) || (rec.CustomerID != _customerID)) {
            TaskManager.ProcessContainer(_container);
            _container = new Container();
        }
        _container.Add((dynamic)rec);
    }
