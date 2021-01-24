    public OrderModel(string inOrderModel){
        var splitString = inOrderModel.Split(';');
        ManagerSurname = splitString[1];
        // etc
    }
